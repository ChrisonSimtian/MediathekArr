namespace MediathekViewWeb.Models;

public class MediaItem
{
    public string Channel { get; set; } // Channel name (e.g., "ARD", "ZDF")
    public string Topic { get; set; } // Topic or category
    public string Title { get; set; } // Title of the media item
    public string Description { get; set; } // Description of the media item
    public long Timestamp { get; set; } // Unix timestamp for the media item
    public int Duration { get; set; } // Duration in seconds
    public long Size { get; set; } // File size in bytes
    public string UrlWebsite { get; set; } // URL to the media item's website
    public string UrlSubtitle { get; set; } // URL to subtitles (if available)
    public string UrlVideo { get; set; } // URL to the video file
    public string UrlVideoLow { get; set; } // URL to the low-quality video file
    public string UrlVideoHd { get; set; } // URL to the HD video file
    public string FilmlisteTimestamp { get; set; } // Timestamp of the film list
    public string Id { get; set; } // Unique ID of the media item
}
