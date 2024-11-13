using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MediathekArr.Tests;
using MediathekArr.Tests.Fixtures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediathekArr.Infrastructure.Tests;

public class MediathekArrContextUnitTests(TestWebApplicationFactory factory) : AbstractIntegratedUnitTest(factory)
{
    [Fact]
    public void DependencyInjection_Fact()
    {
        // Arrange
        var connectionString = Configuration.GetConnectionString(Constants.ConfigurationConstants.MediathekArrConnectionString);
        var mediathekArrContext = ScopedServiceProvider.GetRequiredService<MediathekArrContext>();

        // Assert
        connectionString.Should().NotBeNull("MediathekArrContext ConnectionString missing from appsettings.config");
        mediathekArrContext.Should().NotBeNull("MediathekArrContext missing from DI");
    }
}
