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
    $loadImages  # Add this parameter to optionally load images after building
)

# Ensure the script is run from the correct directory
if ($PSScriptRoot -ne (Get-Location).Path) {
    Write-Warning "This script should be run from the directory it is located in: $PSScriptRoot"
    Write-Warning "Current directory: $(Get-Location)"
    Set-Location -Path $PSScriptRoot
}
# Ensure the script is run with PowerShell Core
if ($PSVersionTable.PSEdition -ne 'Core') {
    Write-Error "This script must be run with PowerShell Core (pwsh)."
    exit 1
}

# Ensure the .NET SDK is installed
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    Write-Error "The .NET SDK is not installed or not in the PATH."
    exit 1
}

# Ensure Docker is available
if (-not (Get-Command docker -ErrorAction SilentlyContinue)) {
    Write-Error "Docker is not installed or not in the PATH."
    exit 1
}

# Set up the paths for the artifacts and source code
$artifactsFolder = Join-Path -Path $PSScriptRoot -ChildPath '..\artifacts'
$imagesFolder = Join-Path -Path $artifactsFolder -ChildPath 'images'
$imagesFolder = [System.IO.Path]::GetFullPath($imagesFolder)

$sourceFolder = Join-Path -Path $PSScriptRoot -ChildPath '..\src'

# Ensure the artifacts/images directory exists
if (-not (Test-Path -Path $imagesFolder)) {
    New-Item -Path $imagesFolder -ItemType Directory -Force | Out-Null
}

# clean up old images
if (Test-Path -Path $imagesFolder) {
    Get-ChildItem -Path $imagesFolder -Filter '*.tar.gz' | ForEach-Object {
        Remove-Item -Path $_.FullName -Force
    }
    Write-Host "Cleaned up old images in: $imagesFolder"
}

# Build the baseline Docker image from Dockerfile
Write-Host "🔧 Building baseline Docker image..."
# Use buildx for multi-platform builds
$imageName = "mediathekarr-baseline"
$tag = "latest"
$tagName = "$($imageName):$($tag)"
# Output as gzip compressed tarball
$outputTar = "$imageName-$tag.tar"
$tarPath = Join-Path -Path $imagesFolder -ChildPath $outputTar
$outputGz = "$outputTar.gz"
$gzPath = Join-Path -Path $imagesFolder -ChildPath $outputGz
$dockerfile = "Dockerfile"
# Build for AMD64 and ARM64 platforms
$platforms = "linux/amd64,linux/arm64"


# Load into Docker
docker buildx build `
    --platform $platforms `
    --pull `
    --load `
    --file $dockerfile `
    --tag $tagName `
    ..

# Export the baseline image as tarball
Write-Host "📦 Exporting image as tarball..."
docker save $tagName -o $tarPath
Write-Host "✅ Done! Image loaded and saved as $outputTar"

# Compress using GZipStream
$sourceStream = [System.IO.File]::OpenRead($tarPath)
$targetStream = [System.IO.File]::Create($gzPath)
$gzipStream = New-Object System.IO.Compression.GZipStream($targetStream, [System.IO.Compression.CompressionMode]::Compress)

$sourceStream.CopyTo($gzipStream)

$gzipStream.Dispose()
$sourceStream.Dispose()
$targetStream.Dispose()

# Clean up the uncompressed tarball
Write-Host "🗑️ Cleaning up uncompressed tarball..."
Remove-Item -Path $tarPath -Force

# Check if the compressed image was saved successfully
if ((Test-Path -Path $gzPath)) {
    Write-Host "✅ Compressed image saved as $gzPath"
}
else {
    Write-Error "Failed to save compressed image to: $gzPath"
}

Write-Host "🔧 Building container images for MediathekArr.Server and MediathekArr.Downloader..."

# Build the Docker image for MediathekArr.Server
Push-Location -Path (Join-Path -Path $sourceFolder -ChildPath 'MediathekArr.Server')
Write-Host "🔧 Building container images for MediathekArr.Server..."
dotnet `
    publish --os $os --arch $arch `
    /t:PublishContainer `
    -p ContainerArchiveOutputPath=${imagesFolder}/mediathekarr-server.tar.gz

if ($loadImages) {
    Write-Host "Loading built containers into Docker..."
    
    $serverImage = Join-Path -Path $imagesFolder -ChildPath "mediathekarr-server.tar.gz"
    
    if (Test-Path -Path $serverImage) {
        docker load -i $serverImage
    }
    else {
        Write-Error "Failed to find the server image tarball at: $serverImage"
        exit 1
    }
}

Pop-Location

# Build the Docker image for MediathekArr.Downloader
Push-Location -Path (Join-Path -Path $sourceFolder -ChildPath 'MediathekArr.Downloader')
Write-Host "🔧 Building container images for MediathekArr.Downloader..."
dotnet `
    publish --os $os --arch $arch `
    /t:PublishContainer `
    -p ContainerArchiveOutputPath=${imagesFolder}/mediathekarr-downloader.tar.gz

if ($loadImages) {
    Write-Host "Loading built containers into Docker..."

    $downloaderImage = Join-Path -Path $imagesFolder -ChildPath "mediathekarr-downloader.tar.gz"

    if (Test-Path -Path $downloaderImage) {
        docker load -i $downloaderImage
    }
    else {
        Write-Error "Failed to find the downloader image tarball at: $downloaderImage"
        exit 1
    }
}

Pop-Location

Write-Host "All container images built and saved to: $imagesFolder"
Get-ChildItem -Path $imagesFolder -Filter '*.tar.gz' | ForEach-Object {
    Write-Host "  - $($_.Name)"
}

if ($loadImages) {
    Write-Host "Loaded images:"
    docker images | Select-String "mediathekarr"
}