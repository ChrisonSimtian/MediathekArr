namespace MediathekArr.Domain;

public class Episode
{
    public string Name { get; set; }
    public DateTime Aired { get; set; }
    public int Runtime { get; set; }
    public int SeasonNumber { get; set; }
    public int EpisodeNumber { get; set; }

    public virtual Series Series { get; set; }
}
