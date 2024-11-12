using TVDB;

namespace MediathekArr.Tests
{
    public class TvdbClientUnitTests
    {
        [Fact]
        public async Task GetBearerTokenTvdbClient_Fact()
        {
            var httpClient = new HttpClient();
            var tvDbClient = new TvdbClient(httpClient);
            
            var loginResult = await tvDbClient.LoginAsync(new TVDB.Body
            {
                Apikey = "e82b72fe-8674-4cc1-8cbb-474ed12a3fed",
            });
        }
    }
}
