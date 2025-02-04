namespace MediathekViewWeb.Models;

using System.Collections.Generic;

public class Result
{
    public List<MediaItem> Results { get; set; } // List of media items
    public QueryInfo QueryInfo { get; set; } // Metadata about the query
}