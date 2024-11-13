using System.Text.Json.Serialization;
namespace MediathekArr.Models;

public class Result
{
    [JsonPropertyName("results")]
    public List<ApiResultItem> Results { get; set; }

    [JsonPropertyName("queryInfo")]
    public QueryInfo QueryInfo { get; set; }
}
