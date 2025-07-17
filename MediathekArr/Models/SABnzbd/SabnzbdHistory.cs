using System.Text.Json.Serialization;

namespace MediathekArr.Models.SABnzbd;

public class SabnzbdHistory
{
    [JsonPropertyName("slots")]
    public List<SabnzbdHistoryItem> Items { get; set; }
}
