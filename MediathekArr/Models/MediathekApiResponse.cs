using System.Text.Json.Serialization;
namespace MediathekArr.Models;

public class MediathekApiResponse
{
    [JsonPropertyName("result")]
    public Result Result { get; set; }

    [JsonPropertyName("err")]
    public object Error { get; set; }
}