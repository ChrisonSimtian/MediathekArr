FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Copy and restore dependencies
COPY . ./
RUN dotnet restore

# Publish MediathekArr.Server
WORKDIR /app/MediathekArr.Server
RUN dotnet publish -c Release -o /app/out/MediathekArr.Server

# Publish MediathekArr.Downloader
WORKDIR /app/MediathekArr.Downloader
RUN dotnet publish -c Release -o /app/out/MediathekArr.Downloader

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Install required packages
RUN apt-get update && apt-get install -y \
    tar \
    xz-utils \
    gosu \
    wget \
    gnupg \
    && rm -rf /var/lib/apt/lists/*

# Add MKVToolNix repository and install
RUN wget -O /etc/apt/keyrings/gpg-pub-moritzbunkus.gpg https://mkvtoolnix.download/gpg-pub-moritzbunkus.gpg && \
    echo "deb [signed-by=/etc/apt/keyrings/gpg-pub-moritzbunkus.gpg] https://mkvtoolnix.download/debian/ bookworm main" > /etc/apt/sources.list.d/mkvtoolnix.download.list && \
    apt-get update && apt-get install -y \
    mkvtoolnix

# Set working directory
WORKDIR /app

# Copy the built apps from the build environment
COPY --from=build-env /app/out/MediathekArr.Server /app/MediathekArr.Server
COPY --from=build-env /app/out/MediathekArr.Downloader /app/MediathekArr.Downloader

# Copy the startup script
COPY docker_start.sh /app/docker_start.sh
RUN chmod +x /app/docker_start.sh

# Create required directories
RUN mkdir -p /data/mediathek/incomplete /data/mediathek/complete

ENV ASPNETCORE_ENVIRONMENT=Production
ENV CONFIG_PATH=/app/config

# Use the shell script to start both processes
ENTRYPOINT ["/app/docker_start.sh"]
