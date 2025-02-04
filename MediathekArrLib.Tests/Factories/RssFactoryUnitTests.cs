using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediathekArr.Models.Newznab;

namespace MediathekArr.Factories;

public class RssFactoryUnitTests
{
    [Fact]
    public async void Empty_Fact()
    {
        // Arrange
        Rss rssResult;

        // Act
        rssResult = RssFactory.Empty;

        // Assert
        rssResult.ShouldNotBeNull();

        // Assert Channel
        rssResult.Channel.ShouldNotBeNull();
        rssResult.Channel.Title.ShouldBeEquivalentTo("MediathekArr");
        rssResult.Channel.Description.ShouldBeEquivalentTo("MediathekArr API results");
        rssResult.Channel.Items.ShouldBeEmpty();

        // Assert Channel Response
        rssResult.Channel.Response.ShouldNotBeNull();
        rssResult.Channel.Response.Offset.ShouldBe(0);
        rssResult.Channel.Response.Total.ShouldBe(0);
    }
}