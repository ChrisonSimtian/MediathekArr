using FluentAssertions;
using TVDB;

namespace MediathekArr.Tests
{
    public class TvdbClientUnitTests
    {
        [Fact]
        public async Task GetBearerTokenTvdbClient_Fact()
        {
            var tvDbClient = new LoginClient(new HttpClient());
            
            var loginResult = await tvDbClient.LoginAsync(new TVDB.Models.Body
            {
                Apikey = "e82b72fe-8674-4cc1-8cbb-474ed12a3fed",
            });

            loginResult.Data.Token.Should().NotBeEmpty();
        }

        [Fact]
        public async Task TestBearerClient_Fact()
        {
            var tvDbClient = new AwardsClient(new HttpClient(new BearerTokenHandler()
            {
                ApiKey = "e82b72fe-8674-4cc1-8cbb-474ed12a3fed"
            }));

            var result = await tvDbClient.AwardsGetAsync();
            result.Status.Should().Be("success");
        }
    }
}