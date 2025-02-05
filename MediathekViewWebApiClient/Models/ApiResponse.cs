using System.Text.Json.Serialization;

namespace MediathekViewWeb.Models;

public class ApiResponse
{
    /// <summary>
    /// Result of the API call
    /// </summary>
    [JsonPropertyName("result")]
    public Result Result { get; set; }

    /// <summary>
    /// Error message, if any
    /// </summary>
    [JsonPropertyName("err")]
    public string ErrorMessage { get; set; }
}
