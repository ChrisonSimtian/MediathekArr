using FluentAssertions;
using MediathekArr.Models;
using MediathekArr.Models.Newznab;
using MediathekArr.Models.Rulesets;
using MediathekArr.Utilities;
using System.Xml.Linq;

namespace MediathekArr.Tests.Utilities;

public class NewznabUtilsUnitTests
{
    [Test]
    public void GenerateAttributes_WithApiResultItem_AllParameters_ReturnsCorrectAttributes()
    {
        // Arrange
        var item = new ApiResultItem
        {
            UrlSubtitle = "http://example.com/subtitle"
        };
        var season = "01";
        var episode = "05";
        var categoryValues = new[] { "5040", "5070" };
        var episodeType = EpisodeType.Standard;
        var airDate = new DateTime(2023, 12, 25);

        // Act
        var result = NewznabUtils.GenerateAttributes(item, season, episode, categoryValues, episodeType, airDate);

        // Assert
        result.Should().HaveCount(6);
        result.Should().ContainSingle(a => a.Name == "category" && a.Value == "5040");
        result.Should().ContainSingle(a => a.Name == "category" && a.Value == "5070");
        result.Should().ContainSingle(a => a.Name == "season" && a.Value == "01");
        result.Should().ContainSingle(a => a.Name == "episode" && a.Value == "05");
        result.Should().ContainSingle(a => a.Name == "tvairdate" && a.Value == "2023-12-25");
        result.Should().ContainSingle(a => a.Name == "seriestype" && a.Value == "Standard");
    }

    [Test]
    public void GenerateAttributes_WithApiResultItem_NoSubtitle_AddsGermanSubs()
    {
        // Arrange
        var item = new ApiResultItem
        {
            UrlSubtitle = null
        };
        var categoryValues = new[] { "5040" };
        var episodeType = EpisodeType.Standard;

        // Act
        var result = NewznabUtils.GenerateAttributes(item, null, null, categoryValues, episodeType);

        // Assert
        result.Should().ContainSingle(a => a.Name == "subs" && a.Value == "German");
    }

    [Test]
    public void GenerateAttributes_WithApiResultItem_EmptySubtitle_AddsGermanSubs()
    {
        // Arrange
        var item = new ApiResultItem
        {
            UrlSubtitle = ""
        };
        var categoryValues = new[] { "5040" };
        var episodeType = EpisodeType.Standard;

        // Act
        var result = NewznabUtils.GenerateAttributes(item, null, null, categoryValues, episodeType);

        // Assert
        result.Should().ContainSingle(a => a.Name == "subs" && a.Value == "German");
    }

    [Test]
    public void GenerateAttributes_WithApiResultItem_HasSubtitle_DoesNotAddSubs()
    {
        // Arrange
        var item = new ApiResultItem
        {
            UrlSubtitle = "http://example.com/subtitle"
        };
        var categoryValues = new[] { "5040" };
        var episodeType = EpisodeType.Standard;

        // Act
        var result = NewznabUtils.GenerateAttributes(item, null, null, categoryValues, episodeType);

        // Assert
        result.Should().NotContain(a => a.Name == "subs");
    }

    [Test]
    public void GenerateAttributes_WithApiResultItem_NullSeason_DoesNotAddSeason()
    {
        // Arrange
        var item = new ApiResultItem();
        var categoryValues = new[] { "5040" };
        var episodeType = EpisodeType.Standard;

        // Act
        var result = NewznabUtils.GenerateAttributes(item, null, null, categoryValues, episodeType);

        // Assert
        result.Should().NotContain(a => a.Name == "season");
    }

    [Test]
    public void GenerateAttributes_WithApiResultItem_NullEpisode_DoesNotAddEpisode()
    {
        // Arrange
        var item = new ApiResultItem();
        var categoryValues = new[] { "5040" };
        var episodeType = EpisodeType.Standard;

        // Act
        var result = NewznabUtils.GenerateAttributes(item, null, null, categoryValues, episodeType);

        // Assert
        result.Should().NotContain(a => a.Name == "episode");
    }

    [Test]
    public void GenerateAttributes_WithApiResultItem_NullAirDate_DoesNotAddTvAirDate()
    {
        // Arrange
        var item = new ApiResultItem();
        var categoryValues = new[] { "5040" };
        var episodeType = EpisodeType.Standard;

        // Act
        var result = NewznabUtils.GenerateAttributes(item, null, null, categoryValues, episodeType, null);

        // Assert
        result.Should().NotContain(a => a.Name == "tvairdate");
    }

    [Test]
    public void GenerateAttributes_WithApiResultItem_MultipleCategoryValues_AddsAllCategories()
    {
        // Arrange
        var item = new ApiResultItem();
        var categoryValues = new[] { "5040", "5070", "5080" };
        var episodeType = EpisodeType.Standard;

        // Act
        var result = NewznabUtils.GenerateAttributes(item, null, null, categoryValues, episodeType);

        // Assert
        var categoryAttributes = result.Where(a => a.Name == "category").ToList();
        categoryAttributes.Should().HaveCount(3);
        categoryAttributes.Should().ContainSingle(a => a.Value == "5040");
        categoryAttributes.Should().ContainSingle(a => a.Value == "5070");
        categoryAttributes.Should().ContainSingle(a => a.Value == "5080");
    }

    [Test]
    public void GenerateAttributes_WithApiResultItem_EmptyCategoryValues_DoesNotAddCategories()
    {
        // Arrange
        var item = new ApiResultItem();
        var categoryValues = Array.Empty<string>();
        var episodeType = EpisodeType.Standard;

        // Act
        var result = NewznabUtils.GenerateAttributes(item, null, null, categoryValues, episodeType);

        // Assert
        result.Should().NotContain(a => a.Name == "category");
    }

    [Test]
    [Arguments(EpisodeType.Standard, "Standard")]
    [Arguments(EpisodeType.Daily, "Daily")]
    [Arguments(EpisodeType.Anime, "Anime")]
    public void GenerateAttributes_WithApiResultItem_DifferentEpisodeTypes_AddsCorrectSeriesType(EpisodeType episodeType, string expectedValue)
    {
        // Arrange
        var item = new ApiResultItem();
        var categoryValues = new[] { "5040" };

        // Act
        var result = NewznabUtils.GenerateAttributes(item, null, null, categoryValues, episodeType);

        // Assert
        result.Should().ContainSingle(a => a.Name == "seriestype" && a.Value == expectedValue);
    }

    [Test]
    public void GenerateAttributes_WithMatchedEpisodeInfo_CallsOverloadedMethod()
    {
        // Arrange
        var item = new ApiResultItem
        {
            UrlSubtitle = "http://example.com/subtitle"
        };
        var episode = new Models.Tvdb.Episode(
            Name: "Test Episode",
            Aired: new DateTime(2023, 6, 15),
            Runtime: 45,
            SeasonNumber: 2,
            EpisodeNumber: 10
        );
        var matchedEpisodeInfo = new MatchedEpisodeInfo(
            ShowName: "Test Show",
            MatchedTitle: "Test Matched Title",
            Item: item,
            Episode: episode
        );
        var categoryValues = new[] { "5040" };
        var episodeType = EpisodeType.Daily;

        // Act
        var result = NewznabUtils.GenerateAttributes(matchedEpisodeInfo, categoryValues, episodeType);

        // Assert
        result.Should().HaveCount(5);
        result.Should().ContainSingle(a => a.Name == "category" && a.Value == "5040");
        result.Should().ContainSingle(a => a.Name == "season" && a.Value == "02");
        result.Should().ContainSingle(a => a.Name == "episode" && a.Value == "10");
        result.Should().ContainSingle(a => a.Name == "tvairdate" && a.Value == "2023-06-15");
        result.Should().ContainSingle(a => a.Name == "seriestype" && a.Value == "Daily");
    }

    [Test]
    public void SerializeRss_ValidRss_ReturnsXmlString()
    {
        // Arrange
        var rss = new Rss
        {
            Channel = new Channel
            {
                Title = "Test Channel",
                Description = "Test Description",
                Response = new Response
                {
                    Offset = 0,
                    Total = 1
                },
                Items = new List<Item>
                {
                    new Item
                    {
                        Title = "Test Item",
                        Description = "Test Item Description",
                        Attributes = new List<MediathekArr.Models.Newznab.Attribute>
                        {
                            new MediathekArr.Models.Newznab.Attribute { Name = "category", Value = "5040" }
                        }
                    }
                }
            }
        };

        // Act
        var result = NewznabUtils.SerializeRss(rss);

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().Contain("<?xml");
        result.Should().Contain("Test Channel");
        result.Should().Contain("Test Description");
        result.Should().Contain("Test Item");
        result.Should().Contain("xmlns:newznab=\"http://www.newznab.com/DTD/2010/feeds/attributes/\"");
    }

    [Test]
    public void SerializeRss_WithNewznabAttributes_FixesNamespaceIssue()
    {
        // Arrange
        var rss = new Rss
        {
            Channel = new Channel
            {
                Title = "Test",
                Description = "Test",
                Response = new Response { Offset = 0, Total = 0 },
                Items = new List<Item>
                {
                    new Item
                    {
                        Title = "Test",
                        Attributes = new List<MediathekArr.Models.Newznab.Attribute>
                        {
                            new MediathekArr.Models.Newznab.Attribute { Name = "category", Value = "5040" }
                        }
                    }
                }
            }
        };

        // Act
        var result = NewznabUtils.SerializeRss(rss);

        // Assert
        result.Should().NotContain(":newznab_x003A_");
        result.Should().Contain("newznab:");
    }

    [Test]
    public void SerializeRss_EmptyRss_ReturnsValidXml()
    {
        // Arrange
        var rss = new Rss
        {
            Channel = new Channel
            {
                Title = "Empty",
                Description = "Empty",
                Response = new Response { Offset = 0, Total = 0 },
                Items = new List<Item>()
            }
        };

        // Act
        var result = NewznabUtils.SerializeRss(rss);

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().Contain("<?xml");
        
        // Verify it's valid XML
        var act = () => XDocument.Parse(result);
        act.Should().NotThrow();
    }

    [Test]
    public void GetEmptyRssResult_ReturnsValidEmptyRss()
    {
        // Act
        var result = NewznabUtils.GetEmptyRssResult();

        // Assert
        result.Should().NotBeNull();
        result.Channel.Should().NotBeNull();
        result.Channel.Title.Should().Be("MediathekArr");
        result.Channel.Description.Should().Be("MediathekArr API results");
        result.Channel.Items.Should().BeEmpty();
        result.Channel.Response.Should().NotBeNull();
        result.Channel.Response.Offset.Should().Be(0);
        result.Channel.Response.Total.Should().Be(0);
    }

    [Test]
    public void GetEmptyRssResult_CalledMultipleTimes_ReturnsDifferentInstances()
    {
        // Act
        var result1 = NewznabUtils.GetEmptyRssResult();
        var result2 = NewznabUtils.GetEmptyRssResult();

        // Assert
        result1.Should().NotBeSameAs(result2);
        result1.Channel.Should().NotBeSameAs(result2.Channel);
    }

    [Test]
    public void GetEmptyRssResult_CanBeSerializedSuccessfully()
    {
        // Arrange
        var emptyRss = NewznabUtils.GetEmptyRssResult();

        // Act
        var act = () => NewznabUtils.SerializeRss(emptyRss);

        // Assert
        act.Should().NotThrow();
        var result = act();
        result.Should().NotBeNullOrEmpty();
        result.Should().Contain("MediathekArr");
    }
}