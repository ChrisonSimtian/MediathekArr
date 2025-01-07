using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TvdbClient.Models;
using TvdbClient.Provider;
using Xunit.Abstractions;

namespace TvdbClient.Tests;

public class AuthenticationUnitTests(ITestOutputHelper outputHelper)
{
    public ITestOutputHelper OutputHelper { get; } = outputHelper;

    [Fact]
    public async void ManuallyAuthenticate_Fact()
    {
        // Arrange
        var config = new Configuration.TvdbConfiguration
        {
            BaseUrl = "https://api4.thetvdb.com/v4",
            ApiKey = "e82b72fe-8674-4cc1-8cbb-474ed12a3fed"
        };
        var httpClient = new HttpClient();
        var requestBody = new StringContent(JsonSerializer.Serialize(new { apikey = config.ApiKey }), System.Text.Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);

        // Act
        var response = await httpClient.PostAsync(config.TokenUrl, requestBody);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ApiResponseWrapper<Token>>(responseData);

        // Assert

        /* Validate Wrapper, Response should be a success */
        result.Should().NotBeNull();
        result.Status.Should().Be("success");
        result.IsSuccess.Should().BeTrue();

        /* Validate Data, Token should be populated and valid for a month */
        result.Data.Should().NotBeNull();
        var token = result.Data;
        token.TokenType.Should().Be("Bearer");
        token.CreationTimestamp.Should().BeBefore(DateTime.Now);
        token.IsTokenExpired.Should().BeFalse();
        token.TokenExpiryDate.Should().BeCloseTo(DateTime.Today.AddMonths(1), TimeSpan.FromDays(1)); // should be roughly a month, +/- a day
        
        token.AccessToken.Should().NotBeNullOrEmpty();
    }

}