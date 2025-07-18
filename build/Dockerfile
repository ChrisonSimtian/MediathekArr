# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS mediathekarr-baseline

# Install required packages
RUN apt-get update \
    && apt-get install -y curl gnupg gosu tar wget xz-utils \
    && rm -rf /var/lib/apt/lists/* \
    && curl -sS https://mkvtoolnix.download/gpg-pub-moritzbunkus.gpg | apt-key add - \
    && echo "deb https://mkvtoolnix.download/debian/ bookworm main" | tee /etc/apt/sources.list.d/mkvtoolnix.download.list \
    && apt-get update && apt-get install -y mkvtoolnix && rm -rf /var/lib/apt/lists/* \
    && mkdir -p /data/mediathek/incomplete /data/mediathek/complete