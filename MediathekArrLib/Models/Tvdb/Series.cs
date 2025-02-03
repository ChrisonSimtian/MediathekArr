using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediathekArr.Models.Tvdb;

[Table("Series", Schema = "Tvdb")]
public class Series
{
    [Key]
    public int SeriesId { get; set; }
    public string? Name { get; set; }
    public string? GermanName { get; set; }
    public string? Aliases { get; set; }
    public DateTime LastUpdated { get; set; }
    public DateTime? NextAired { get; set; }
    public DateTime? LastAired { get; set; }
    public DateTime CacheExpiry { get; set; }
    public virtual List<Episode> Episodes { get; set; }
}