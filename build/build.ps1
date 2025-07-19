[CmdletBinding()]
param (
    [Parameter()]
    [string]
    $os = 'linux',
    [Parameter()]
    [string]
    $arch = 'x64',
    [Parameter()]
    [switch]
    $loadImages,  # Add this parameter to optionally load images after building
    
    # Debugging and Verbose Preferences
    $VerbosePreference = 'Continue',
    $DebugPreference = 'Continue',
    $InformationPreference = 'Continue',
    $ErrorActionPreference = 'Stop'
)
<#
    .SYNOPSIS
    Sets the current Directory to where the build script sits
    .DESCRIPTION
    This function checks if the current directory is the same as the script's directory.
#>
function Set-CurrentDirectory {
    Write-Debug "🔄 Making sure the current directory is the same as the script's directory..."
    if ($PSScriptRoot -ne (Get-Location).Path) {
        Write-Warning "⚠️ This script should be run from the directory it is located in: $PSScriptRoot"
        Write-Warning "🔶 Current directory: $(Get-Location)"
        Set-Location -Path $PSScriptRoot
        Write-Verbose "✅ Changed directory to: $PSScriptRoot"
    } 
    Write-Information "☑️ Current directory: $PSScriptRoot"
}

<#
    .SYNOPSIS
    Checks if the script is running as PowerShell Core (pwsh).
    .DESCRIPTION
    This function checks if the script is running in PowerShell Core and exits with an error if not.
#>
function Invoke-RunsAsPowershellCore {
    Write-Debug "🔄 Checking if the script is running as PowerShell Core..."
    if ($PSVersionTable.PSEdition -ne 'Core') {
        Write-Error "❌ This script must be run with PowerShell Core (pwsh)."
        throw "PowerShell Core is required to run this script."
    }
    Write-Information "☑️ Running as PowerShell Core (pwsh)."
    Write-Verbose "🔧 PowerShell version: $($PSVersionTable.PSVersion)"
}

<#
    .SYNOPSIS
    Checks if the .NET SDK is installed.
    .DESCRIPTION
    This function checks if the .NET SDK is installed and available in the PATH.
#>
function Invoke-DotnetSdkInstalled {
    Write-Debug "🔄 Checking if the .NET SDK is installed..."
    if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
        Write-Error "❌ The .NET SDK is not installed or not in the PATH."
        throw "The .NET SDK is not installed or not in the PATH."
    }
    Write-Information "☑️ .NET SDK installed"
    Write-Verbose "🔧 .NET SDK version: $(dotnet --version)"
}

<#
    .SYNOPSIS
    Checks if Docker is installed.
    .DESCRIPTION
    This function checks if Docker is installed and available in the PATH.
#>
function Invoke-DockerInstalled {
    Write-Debug "🔄 Checking if Docker is installed..."
    if (-not (Get-Command docker -ErrorAction SilentlyContinue)) {
        Write-Error "❌ Docker is not installed or not in the PATH."
        throw "Docker is not installed or not in the PATH."
    }
    Write-Information "☑️ Docker installed"
    Write-Verbose "🔧 Docker version: $(docker --version)"
}

<#
    .SYNOPSIS
    Sets up the folder structure for the build artifacts.
    .DESCRIPTION
    This function creates the necessary folder structure for storing build artifacts.
#>
function Invoke-FolderStructure {
    Write-Debug "🔄 Setting up folder paths..."

    # Ensure the script is run from the correct directory
    Set-CurrentDirectory

    # Set up the root folder
    Write-Debug "🔄 Setting up root folder for artifacts..."
    $script:rootFolder = Join-Path -Path $PSScriptRoot -ChildPath '..'
    $script:rootFolder = [System.IO.Path]::GetFullPath($script:rootFolder)
    Write-Verbose "📁 Root folder: $script:rootFolder"

    # Set up the paths for the artifacts
    Write-Debug "🔄 Setting up artifacts folder..."
    $script:artifactsFolder = Join-Path -Path $script:rootFolder -ChildPath 'artifacts'
    $script:artifactsFolder = [System.IO.Path]::GetFullPath($script:artifactsFolder)
    Write-Verbose "📁 Artifacts folder: $script:artifactsFolder"

    # Set up the images folder within artifacts
    $script:imagesFolder = Join-Path -Path $script:artifactsFolder -ChildPath 'images'
    $script:imagesFolder = [System.IO.Path]::GetFullPath($script:imagesFolder)
    if (-not (Test-Path -Path $script:imagesFolder)) {
        New-Item -Path $script:imagesFolder -ItemType Directory -Force | Out-Null
        Write-Information "📁 Created images folder: $script:imagesFolder"
    }

    # Set up the source folder
    Write-Debug "🔄 Setting up source folder..."
    $script:sourceFolder = Join-Path -Path $script:rootFolder -ChildPath 'src'
    $script:sourceFolder = [System.IO.Path]::GetFullPath($script:sourceFolder)
    Write-Verbose "📁 Source folder: $script:sourceFolder"

    Write-Information "🎉 Folder paths set up successfully!"
}

function Invoke-Cleanup {
    Write-Information "🔄 Cleaning up old build artifacts..."
    # clean up old images
    if (Test-Path -Path $script:imagesFolder) {
        Write-Verbose "🔄 Cleaning up old images in: $script:imagesFolder"
        Get-ChildItem -Path $script:imagesFolder -Filter '*.tar.gz' | ForEach-Object {
            Remove-Item -Path $_.FullName -Force
            Write-Verbose "🗑️ Removed old image: $($_.Name)"
        }
        Write-Information "🧹 Cleaned up old images in: $script:imagesFolder"
    }
}

function Invoke-SetupBuildEnvironment {
    Write-Information "🔄 Setting up build environment..."

    # Check if pre-requisits are met
    Write-Verbose "🔄 Checking pre-requisites..."
    Invoke-RunsAsPowershellCore
    Invoke-DotnetSdkInstalled
    Invoke-DockerInstalled
    Write-Information "✅ Pre-requisites met!"

    # Set up folder structure
    Invoke-FolderStructure

    # Cleanup
    Invoke-Cleanup

    Write-Information "✅ Build environment set up successfully!"
}

function Invoke-BuildBaselineImage {
    [CmdletBinding()]
    param (
        [Parameter()]
        [string]
        $imageName = 'mediathekarr-baseline',
        [Parameter()]
        [string]
        $tag = 'latest',
        [Parameter()]
        [string]
        $platforms = 'linux/amd64',
        [Parameter()]
        [switch]
        $saveImage
    )
    # Build the baseline Docker image from Dockerfile
    Write-Debug "🔄 Building baseline Docker image..."

    $tagName = "$($imageName):$($tag)"
    Write-Verbose "🔧 Building image: $tagName for platforms: $platforms"

    # Dockerfile Valdiation
    $dockerfile = "Dockerfile"
    Write-Verbose "📂 Using Dockerfile: $dockerfile"
    if ( -not (Test-Path -Path $dockerfile)) {
        Write-Error "❌ Dockerfile not found at: $dockerfile"
        throw "Dockerfile not found"
    }

    # Use buildx for multi-platform builds
    Write-Debug "🔄 Building Docker image..."
    docker build `
        --platform $platforms `
        --pull `
        --file $dockerfile `
        --tag $tagName `
        ..

    # Check if the build was successful
    Write-Debug "🔄 Checking if Docker build was successful..."
    if ($LASTEXITCODE -ne 0) {
        Write-Error "❌ Failed to build the baseline image: $tagName"
        throw "Docker build failed"
    }
    Write-Information "✅ Baseline image built successfully: $tagName"

    if ($saveImage) {
        # Save the image as a tarball
        Write-Debug "🔄 Saving the baseline image as a tarball..."
        $outputTar = "$imageName-$tag.tar"
        $tarPath = Join-Path -Path $imagesFolder -ChildPath $outputTar
        $outputGz = "$outputTar.gz"
        $gzPath = Join-Path -Path $imagesFolder -ChildPath $outputGz
    
        # Export the baseline image as tarball
        Write-Verbose "📦 Exporting image as tarball..."
        docker save $tagName -o $tarPath
        if ($LASTEXITCODE -ne 0) {
            Write-Error "❌ Failed to export the image as tarball: $tarPath"
            throw "Docker save failed"
        }
        Write-Verbose "🎉 Done! Image loaded and saved as $outputGz"

        # Compress using GZipStream
        $sourceStream = [System.IO.File]::OpenRead($tarPath)
        $targetStream = [System.IO.File]::Create($gzPath)
        $gzipStream = New-Object System.IO.Compression.GZipStream($targetStream, [System.IO.Compression.CompressionMode]::Compress)

        $sourceStream.CopyTo($gzipStream)

        $gzipStream.Dispose()
        $sourceStream.Dispose()
        $targetStream.Dispose()

        # Clean up the uncompressed tarball
        Write-Debug "🗑️ Cleaning up uncompressed tarball..."
        Remove-Item -Path $tarPath -Force

        # Check if the compressed image was saved successfully
        if ((Test-Path -Path $gzPath)) {
            Write-Information "✅ image saved as $gzPath"
        }
        else {
            Write-Error "❌ Failed to compress image"
            throw "Failed to compress image"
        }
    }
    
}

function Invoke-DotnetDockerPublish {
    [CmdletBinding()]
    param (
        [Parameter()]
        [string]
        $projectName,
        [Parameter()]
        [string]
        $imageName = 'mediathekarr-server',
        [Parameter()]
        [string]
        $sourceFolder,
        [Parameter()]
        [string]
        $imagesFolder,
        [Parameter()]
        [string]
        $os = 'linux',
        [Parameter()]
        [string]
        $arch = 'x64',
        [Parameter()]
        [switch]
        $loadImages  # Add this parameter to optionally load images after building
    )
    # Build the Docker image for MediathekArr.Server
    Push-Location -Path (Join-Path -Path $sourceFolder -ChildPath $projectName)
    Write-Debug "🔧 Building container images for $projectName..."
    dotnet `
        publish --os $os --arch $arch `
        /t:PublishContainer `
        -p ContainerArchiveOutputPath=${imagesFolder}/$imageName.tar.gz

    # Check if the build was successful
    if ($LASTEXITCODE -ne 0) {
        Write-Error "❌ Failed to build the container image for $projectName"
        throw "Container image build failed"
    }
    if (Test-Path -Path $imagesFolder) {
        Write-Information "✅ Container image for $projectName built successfully"
    }
    else {
        Write-Error "❌ Failed to build the container image for $projectName"
        throw "Container image build failed"
    }

    if ($loadImages) {
        Write-Debug "🔄 Loading built containers into Docker..."

        $imageFilePath = Join-Path -Path $imagesFolder -ChildPath "$imageName.tar.gz"
    
        if (Test-Path -Path $imageFilePath) {
            Write-Verbose "📦 Loading image from: $imageFilePath"
            docker load -i $imageFilePath
        }
        else {
            Write-Error "❌ Failed to find the image file at: $imageFilePath"
            throw "Image file not found"
        }
    }

    Pop-Location
}

# Set up Build Environment
Invoke-SetupBuildEnvironment

# Define Build Parameters for Dotnet Builds
$serverBuildParameters = @{
    projectName  = 'MediathekArr.Server'
    imageName    = 'mediathekarr-server'
    loadImages    = $true
    sourceFolder = $sourceFolder
    imagesFolder = $imagesFolder
    os           = $os
    arch         = $arch
}

$downloaderBuildParameters = @{
    projectName  = 'MediathekArr.Downloader'
    imageName    = 'mediathekarr-downloader'
    loadImages    = $true
    sourceFolder = $sourceFolder
    imagesFolder = $imagesFolder
    os           = $os
    arch         = $arch
}

Invoke-BuildBaselineImage

Write-Information "🔧 Building container images for MediathekArr.Server and MediathekArr.Downloader..."

# Build the Docker image for MediathekArr.Server
Invoke-DotnetDockerPublish @serverBuildParameters
Invoke-DotnetDockerPublish @downloaderBuildParameters

# List all built images
Write-Verbose "🔄 Listing all built images in: $imagesFolder"
Get-ChildItem -Path $imagesFolder -Filter '*.tar.gz' | ForEach-Object {
    Write-Verbose "  - $($_.Name)"
}

if ($loadImages) {
    Write-Information "🔄 Listing all loaded images..."
    docker images | Select-String "mediathekarr"
}