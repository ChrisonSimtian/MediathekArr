using FluentAssertions;
using MediathekArr.Handler;
using MediathekArr.Tests;
using MediathekArr.Tests.Fixtures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TVDB.Tests;

public class LoginClientUnitTests(TestWebApplicationFactory factory) : AbstractIntegratedUnitTest(factory)
{
    /// <summary>
    /// Test whether our config is set up properly and whether our API Key is still valid
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetBearerToken_Fact()
    {
        // Arrange
        var tvDbClient = new LoginClient(new HttpClient());

        // Act
        var loginResult = await tvDbClient.LoginAsync(new Models.Body
        {
            Apikey = Configuration.GetValue<string>(MediathekArr.Constants.ConfigurationConstants.TvdbApiKey) // TODO: Make config class and inject that way instead,
        });

        // Assert
        loginResult.Status.Should().Be("success", "Bearer Token for TVDB not generated");
        loginResult.Data.Token.Should().NotBeEmpty("Bearer Token for TVDB not generated");
    }

    [Fact]
    public void CheckApiKeyConfig_Fact()
    {
        // Arrange
        var apiKey = Configuration.GetValue<string>(MediathekArr.Constants.ConfigurationConstants.TvdbApiKey); // TODO: Make config class and inject that way instead

        // Assert
        apiKey.Should().NotBeNullOrEmpty("API Token for TVDB not found in appsettings.json");
    }

    [Fact]
    public void DependencyInjection_Fact()
    {
        // Arrange
        var tvdbBearerTokenHandler = ScopedServiceProvider.GetService<TvdbBearerTokenHandler>();
        // TODO: DI for LoginClient

        // Assert
        tvdbBearerTokenHandler.Should().NotBeNull("TvdbBearerTokenHandler is required");
    }

    /// <summary>
    /// Test <see cref="TvdbBearerTokenHandler"/> with a random client
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task BearerTokenHandler_Fact()
    {
        // Arrange
        var randomClient = ScopedServiceProvider.GetRequiredService<SeriesClient>();

        // Act
        var result = await randomClient.SeriesGetAsync(291180);

        // Assert
        result.Status.Should().Be("success", "Bearer Token is invalid");
    }
}