# MediathekArr Baseline Image

Due to how the SDK style container build in dotnet works, it is necessary for us to create a baseline image as a plain old dockerfile.
This Baseline image provides us with all the tools and extras we need but cant provide via SDK builds.

## Mkvtoolnix

This tool allows us to do MKV merges and needs to be installed via package manager.

``` bash
echo "deb https://mkvtoolnix.download/debian/ bookworm main" | tee /etc/apt/sources.list.d/mkvtoolnix.download.list \
apt-get update && apt-get install -y mkvtoolnix
```

## PUID & GUID

Certain environments require specific PUIDs and GUIDs, so we provide defaults for those just in case.
