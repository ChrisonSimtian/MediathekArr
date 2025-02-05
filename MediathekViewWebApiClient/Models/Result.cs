namespace MediathekViewWeb.Models;

using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Result
{
    /// <summary>
    /// List of media items
    /// </summary>
    [JsonPropertyName("results")]
    public List<MediaItem> Results { get; set; }

    /// <summary>
    /// Metadata about the query
    /// </summary>
    [JsonPropertyName("queryInfo")]
    public QueryInfo QueryInfo { get; set; }
}