using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MediathekArr.Models.Tvdb;

[Table("Episodes", Schema = "Tvdb")]
public class Episode
{
    [Key]
    public int Id { get; set; }
    public int SeriesId { get; set; }
    public string? Name { get; set; }
    public DateTime? Aired { get; set; }
    public int? Runtime { get; set; }
    public int? SeasonNumber { get; set; }
    public int? EpisodeNumber { get; set; }

    [ForeignKey(nameof(SeriesId))]
    [JsonIgnore]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public virtual Series Series { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [NotMapped]
    [JsonIgnore]
    public string PaddedSeason => SeasonNumber.HasValue ? SeasonNumber.Value.ToString("D2") : string.Empty;

    [NotMapped]
    [JsonIgnore]
    public string PaddedEpisode => EpisodeNumber.HasValue ? EpisodeNumber.Value.ToString("D2") : string.Empty;
}