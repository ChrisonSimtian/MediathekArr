# Installation
## Docker
## Sonarr
### Download Client
Add a new SABnzbd Download Client in Sonarr -> Settings -> Download Clients
```
Port: 5007
URL Base: api/Downloader
API Key: blank (TODO: Add API Key Authentication)
```
### Indexers
Add a new Indexer in Sonarr -> Settings -> Indexer
```
URL: http://<Your URL>:5007
API Path: api/Indexer
```

## Radarr
## Prowlarr