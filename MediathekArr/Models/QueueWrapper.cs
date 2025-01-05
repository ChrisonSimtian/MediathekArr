using System.Text.Json.Serialization;
using MediathekArr.Models.Sabnzbd;

namespace MediathekArr.Models;

public class QueueWrapper
{
    [JsonPropertyName("queue")]
    public Queue Queue { get; set; }
}
