using TVDB;

namespace System.Net.Http
{
    public class BearerTokenHandler : DelegatingHandler
    {
        public BearerTokenHandler() : base(new HttpClientHandler()) { }
        public string ApiKey { get; set; }
        public async Task<string> RequestToken()
        {
            var tvDbClient = new LoginClient(new HttpClient());

            var loginResult = await tvDbClient.LoginAsync(new TVDB.Models.Body
            {
                Apikey = "e82b72fe-8674-4cc1-8cbb-474ed12a3fed",
            });

            if (loginResult.Status == "success") return loginResult.Data.Token;
            throw new Exception("Failed getting Bearer Token");
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await RequestToken();
            request.Headers.Authorization = new Headers.AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}