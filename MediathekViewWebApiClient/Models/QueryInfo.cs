namespace MediathekViewWeb.Models;

public class QueryInfo
{
    public long FilmlisteTimestamp { get; set; } // Timestamp of the film list
    public string SearchEngineTime { get; set; } // Time taken by the search engine
    public int ResultCount { get; set; } // Number of results in this response
    public int TotalResults { get; set; } // Total number of results available
}