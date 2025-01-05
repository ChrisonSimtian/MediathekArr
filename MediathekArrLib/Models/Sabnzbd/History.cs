using System.Text.Json.Serialization;

namespace MediathekArr.Models.Sabnzbd;

public class History
{
    [JsonPropertyName("slots")]
    public List<HistoryItem> Items { get; set; }
}
