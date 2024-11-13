namespace MediathekArr.Models;

public record TvdbEpisode(string Name, DateTime? Aired, int? Runtime, int SeasonNumber, int EpisodeNumber);