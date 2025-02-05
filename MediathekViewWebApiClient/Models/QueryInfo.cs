using System.Text.Json.Serialization;

namespace MediathekViewWeb.Models;

public class QueryInfo
{
    /// <summary>
    /// Timestamp of the film list
    /// </summary>
    [JsonPropertyName("filmlisteTimestamp")]
    public long FilmlisteTimestamp { get; set; }

    /// <summary>
    /// Time taken by the search engine
    /// </summary>
    [JsonPropertyName("searchEngineTime")]
    public string SearchEngineTime { get; set; }

    /// <summary>
    /// Number of results in this response
    /// </summary>
    [JsonPropertyName("resultCount")]
    public int ResultCount { get; set; }

    /// <summary>
    /// Total number of results available
    /// </summary>
    [JsonPropertyName("totalResults")]
    public int TotalResults { get; set; }
}