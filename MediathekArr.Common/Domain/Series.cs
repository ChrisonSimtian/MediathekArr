namespace MediathekArr.Domain;

public class Series
{
    public int SeriesId { get; set; }
    public string Name { get; set; }
    public string GermanName { get; set; }
    public string Aliases { get; set; }
    public DateTime? LastUpdated { get; set; }
    public DateTime? LastAired { get; set; }
    public DateTime CacheExpiry { get; set; }

    public virtual ICollection<Episode> Episodes { get; set; }
}
