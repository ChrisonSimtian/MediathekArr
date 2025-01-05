using System.Text.Json.Serialization;

namespace MediathekArr.Models.Sabnzbd;

public class QueueItem
{
    [JsonPropertyName("nzo_id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Download Status
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DownloadStatus Status { get; set; }

    /// <summary>
    /// Index
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    /// Estimated Time left
    /// </summary>
    /// <example>0:00:00</example>
    [JsonPropertyName("timeleft")]
    public string Timeleft { get; set; }

    /// <summary>
    /// Size in MB
    /// </summary>
    /// <example>1163.54</example>
    [JsonPropertyName("mb")]
    public string Size { get; set; }

    /// <summary>
    /// Filename
    /// </summary>
    [JsonPropertyName("filename")]
    public string Title { get; set; }

    /// <summary>
    /// Priority
    /// </summary>
    [JsonPropertyName("priority")]
    public string Priority => "Normal";

    /// <summary>
    /// Category
    /// </summary>
    [JsonPropertyName("cat")]
    public string Category { get; set; }

    /// <summary>
    /// Size in MB remaining
    /// </summary>
    /// <example>756.4 MB</example> // @Jones: sure this has MB behind the number?
    [JsonPropertyName("mbleft")]
    public string Sizeleft { get; set; }

    /// <summary>
    /// Percentage
    /// </summary>
    /// <example>34</example>
    [JsonPropertyName("percentage")]
    public string Percentage { get; set; }
}
