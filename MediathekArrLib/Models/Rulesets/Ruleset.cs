using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MediathekArr.Models.Rulesets;

public class Ruleset
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("mediaId")]
    public int MediaId { get; set; }

    [JsonPropertyName("topic")]
    public string Topic { get; set; } = string.Empty; // Raw topic string from API

    [JsonIgnore]
    public virtual List<string> Topics
    {
        get
        {
            // Split the Topic string by commas and return as a list
            return Topic.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
        }
    }

    [JsonPropertyName("priority")]
    public int Priority { get; set; }
    [JsonPropertyName("filters")]
    public string FiltersJson { get; set; } = string.Empty;

    [NotMapped]
    [JsonIgnore]
    public virtual List<Filter> Filters
    {
        get
        {
            return JsonSerializer.Deserialize<List<Filter>>(FiltersJson) ?? [];
        }
    }

    [JsonPropertyName("titleRegexRules")]
    public string TitleRegexRulesJson { get; set; } = string.Empty;

    [NotMapped]
    [JsonIgnore]
    public virtual List<TitleRegexRule> TitleRegexRules
    {
        get
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
            return JsonSerializer.Deserialize<List<TitleRegexRule>>(TitleRegexRulesJson, options) ?? [];
        }
    }

    [JsonPropertyName("episodeRegex")]
    public string? EpisodeRegex { get; set; } = string.Empty;

    [JsonPropertyName("seasonRegex")]
    public string? SeasonRegex { get; set; } = string.Empty;

    [JsonPropertyName("matchingStrategy")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MatchingStrategy MatchingStrategy { get; set; }

    [JsonPropertyName("media")]
    public virtual Media Media { get; set; } = new Media();
}
