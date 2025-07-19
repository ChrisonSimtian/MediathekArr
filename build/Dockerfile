ARG TARGETPLATFORM=linux/arm64

# Build baseline runtime image
FROM --platform=$TARGETPLATFORM mcr.microsoft.com/dotnet/aspnet:9.0 AS mediathekarr-baseline

# Install required packages
RUN apt-get update \
    && apt-get install -y curl gnupg gosu tar wget xz-utils \
    && rm -rf /var/lib/apt/lists/* \
    && curl -sS https://mkvtoolnix.download/gpg-pub-moritzbunkus.gpg | apt-key add - \
    && echo "deb https://mkvtoolnix.download/debian/ bookworm main" | tee /etc/apt/sources.list.d/mkvtoolnix.download.list \
    && apt-get update && apt-get install -y mkvtoolnix && rm -rf /var/lib/apt/lists/* \
    && mkdir -p /data/mediathek/incomplete /data/mediathek/complete

# Set working directory
WORKDIR /app

# Set up environment variables for user IDs
ARG PUID=1000
ARG PGID=1000
ENV PUID=${PUID} \
    PGID=${PGID}

# Create a user and group with specified IDs
RUN addgroup --gid ${PGID} appgroup && \
    adduser --disabled-password --gecos "" --uid ${PUID} --gid ${PGID} appuser