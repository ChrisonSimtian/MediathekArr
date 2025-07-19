# Build

## Build downloader base image

Due to limitations with the SDK style container build, it is not possible to do any ```RUN``` style commands. Instead we need to build a base image that gets used in our dotnet project.
In order to do a multi-platform build, we will be using [buildx](https://docs.docker.com/reference/cli/docker/buildx/build/) instead of the legacy build.

``` bash
docker buildx build `
    --platform 'linux/amd64, linux/arm64' `
    --pull `
    --output type=gzip, dest=mediathekarr-baseline.tar.gz `
    --load
    --file "Dockerfile" `
    --rm -f "Dockerfile" -t "mediathekarr-baseline:latest" ".."
```

``` bash
# Load image
docker load -i ./artifacts/images/mediathekarr-baseline-image.tar.gz

# List all images
docker images

# List only MediathekArr images
docker images | grep mediathekarr

# Or in PowerShell
docker images | Select-String "mediathekarr"
```

## Build container images

[Publish Containers via SDK](https://learn.microsoft.com/en-us/dotnet/core/containers/sdk-publish)
