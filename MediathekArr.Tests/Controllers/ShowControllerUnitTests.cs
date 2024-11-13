using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MediathekArr.Infrastructure;
using MediathekArr.Tests;
using MediathekArr.Tests.Fixtures;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using TVDB;

namespace MediathekArr.Controllers.Tests;

public class ShowControllerUnitTests : AbstractIntegratedUnitTest
{
    public ShowControllerUnitTests(TestWebApplicationFactory factory) : base(factory)
    {
        var mediathekArrContext = ScopedServiceProvider.GetRequiredService<MediathekArrContext>();
        var seriesClient = ScopedServiceProvider.GetRequiredService<SeriesClient>();
        var memoryCache = ScopedServiceProvider.GetRequiredService<IMemoryCache>();
        Controller = new SeriesController(mediathekArrContext, seriesClient,memoryCache);
    }

    SeriesController Controller { get; }

    [Fact]
    public void DependencyInjection_Fact()
    {
        // Arrange
        var mediathekArrContext = ScopedServiceProvider.GetService<MediathekArrContext>();
        var seriesClient = ScopedServiceProvider.GetService<SeriesClient>();
        var memoryCache = ScopedServiceProvider.GetRequiredService<IMemoryCache>();

        // Assert
        mediathekArrContext.Should().NotBeNull("MediathekArrContext missing from DI");
        seriesClient.Should().NotBeNull("SeriesClient missing from DI");
        memoryCache.Should().NotBeNull("MemoryCache missing from DI");
        Controller.Should().NotBeNull("SeriesController could not be constructed");
    }

    [Theory]
    [InlineData(291180)]
    public async Task GetSeriesData_Fact(int tvdbId)
    {
        // Arrange
        var result = Controller.GetSeriesData(tvdbId);

        // Act

        // Assert
        result.Should().NotBeNull();
    }

    [Theory]
    [InlineData(291180)]
    public async Task GetSeriesDataFromTvdb_Fact(int tvdbId)
    {
        // Arrange
        var result = Controller.GetSeriesDataFromTvdb(tvdbId);

        // Act

        // Assert
        result.Should().NotBeNull();
    }
}
