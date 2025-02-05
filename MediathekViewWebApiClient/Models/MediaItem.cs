using System.Text.Json.Serialization;
using MediathekViewWeb.Converters;

namespace MediathekViewWeb.Models;

public class MediaItem
{
    /// <summary>
    /// Channel name (e.g., "ARD", "ZDF")
    /// </summary>
    [JsonPropertyName("channel")]
    public string Channel { get; set; }

    /// <summary>
    /// Topic or category
    /// </summary>
    [JsonPropertyName("topic")]
    public string Topic { get; set; }

    /// <summary>
    /// Title of the media item
    /// </summary>
    [JsonPropertyName("title")]
    [JsonConverter(typeof(DashSanitizerConverter))]
    public string Title { get; set; }

    /// <summary>
    /// Description of the media item
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// Unix timestamp for the media item
    /// </summary>
    [JsonPropertyName("filmlisteTimestamp")]
    [JsonConverter(typeof(NumberOrEmptyConverter<long>))]
    public long Timestamp { get; set; }

    /// <summary>
    /// Duration in seconds
    /// </summary>
    [JsonPropertyName("duration")]
    [JsonConverter(typeof(NumberOrEmptyConverter<int>))]
    public int Duration { get; set; }

    /// <summary>
    /// File size in bytes
    /// </summary>
    [JsonPropertyName("size")]
    [JsonConverter(typeof(NumberOrEmptyConverter<long>))]
    public long Size { get; set; }

    /// <summary>
    /// URL to the media item's website
    /// </summary>
    [JsonPropertyName("url_website")]
    public string UrlWebsite { get; set; }

    /// <summary>
    /// URL to subtitles (if available)
    /// </summary>
    [JsonPropertyName("url_subtitle")]
    public string UrlSubtitle { get; set; }

    /// <summary>
    /// URL to the video file
    /// </summary>
    [JsonPropertyName("url_video")]
    public string UrlVideo { get; set; }

    /// <summary>
    /// URL to the low-quality video file
    /// </summary>
    [JsonPropertyName("url_video_low")]
    public string UrlVideoLow { get; set; }

    /// <summary>
    /// URL to the HD video file
    /// </summary>
    [JsonPropertyName("url_video_hd")]
    public string UrlVideoHd { get; set; }

    /// <summary>
    /// Unique ID of the media item
    /// </summary>
    public string Id { get; set; }

    // TODO: Move this back into the MediathekArr project and solve it there
    [JsonIgnore]
    public string Language => Title?.Contains("(Englisch)") ?? false ? "ENGLISH" : "GERMAN";
}
