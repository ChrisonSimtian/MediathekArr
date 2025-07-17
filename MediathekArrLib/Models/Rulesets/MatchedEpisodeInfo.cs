namespace MediathekArr.Models.Rulesets;

public record MatchedEpisodeInfo(Tvdb.Episode Episode, ApiResultItem Item, string ShowName, string MatchedTitle);
