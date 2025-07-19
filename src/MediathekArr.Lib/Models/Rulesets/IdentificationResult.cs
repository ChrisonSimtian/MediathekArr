namespace MediathekArr.Models.Rulesets;

public record IdentificationResult(string UsedRuleset, string Name, string GermanName, int? SeasonNumber, int? EpisodeNumber, string ItemTitle, Tvdb.Episode MatchedEpisode);