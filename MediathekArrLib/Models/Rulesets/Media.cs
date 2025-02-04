using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MediathekArr.Models.Rulesets;

[Table("Media", Schema = "Rulesets")]
public class Media
{
    [Key]
    [JsonPropertyName("media_id")]
    public int Id { get; set; }

    [JsonPropertyName("media_name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("media_type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("media_tmdbId")]
    public int? TmdbId { get; set; }

    [JsonPropertyName("media_imdbId")]
    public string? ImdbId { get; set; }

    [JsonPropertyName("media_tvdbId")]
    public int? TvdbId { get; set; }
}
