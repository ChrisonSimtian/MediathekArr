using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MediathekArr.Infrastructure;
using MediathekArr.Services;
using MediathekArr.Tests;
using MediathekArr.Tests.Fixtures;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using TVDB;

namespace MediathekArr.Controllers.Tests;

public class IndexerControllerUnitTests: MediathekArrIntegratedUnitTest
{
    public IndexerControllerUnitTests(MediathekArrWebApplicationFactory factory) : base(factory)
    {
        var mediathekSearchService = ScopedServiceProvider.GetRequiredService<MediathekSearchService>();
        var itemLookupService = ScopedServiceProvider.GetRequiredService<ItemLookupService>();
        Controller = new IndexerController(mediathekSearchService, itemLookupService);
    }

    IndexerController Controller { get; }

    [Fact]
    public void DependencyInjection_Fact()
    {
        // Arrange
        var mediathekArrContext = ScopedServiceProvider.GetService<MediathekArrContext>();
        var itemLookupService = ScopedServiceProvider.GetService<ItemLookupService>();

        // Assert
        mediathekArrContext.Should().NotBeNull("MediathekArrContext missing from DI");
        itemLookupService.Should().NotBeNull("ItemLookupService missing from DI");
        Controller.Should().NotBeNull("IndexerController could not be constructed");
    }
}