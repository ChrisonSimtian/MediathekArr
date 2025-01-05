using System.Text.Json.Serialization;
using MediathekArr.Models.Sabnzbd;

namespace MediathekArr.Models;

public class HistoryWrapper
{
    [JsonPropertyName("history")]
    public History History { get; set; }
}
