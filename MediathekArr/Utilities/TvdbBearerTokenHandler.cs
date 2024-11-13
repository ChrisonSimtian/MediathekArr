using TVDB;

namespace System.Net.Http
{
    /// <summary>
    /// Bearer Token implementation for TVDB
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="configuration"></param>
    /// <remarks>
    /// This <see cref="DelegatingHandler"/> gets injected into the <see cref="HttpClient"/> and then takes care of adding the Bearer Token to all HTTP requests
    /// <see href="https://code-maze.com/aspnetcore-using-delegating-handlers-to-extend-httpclient/"/>
    /// </remarks>
    public class TvdbBearerTokenHandler(ILogger<TvdbBearerTokenHandler> logger, IConfiguration configuration) : DelegatingHandler()
    {
        #region Properties
        public IConfiguration Configuration { get; } = configuration;
        public ILogger<TvdbBearerTokenHandler> Logger { get; } = logger;

        /// <summary>
        /// Bearer Token
        /// </summary>
        public string? Token { get; private set; } // TODO: We should somehow cache this token. But also need to find out how long its valid in order to cache it, so leave it be for now
        #endregion

        #region Methods
        /// <summary>
        /// Acquire the Bearer Token
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> AcquireToken()
        {
            if (string.IsNullOrEmpty(Configuration.GetValue<string>(MediathekArr.Constants.ConfigurationConstants.TvdbApiKey)))
            {
                Logger.LogError("TvDbApiKey not configured");
                throw new Exception("TvDbApiKey not configured");
            }

            // This only acquires the Token if its not set
            if (string.IsNullOrEmpty(Token))
            {
                // get a dummy login client with a blank http client
                var tvDbClient = new LoginClient(new HttpClient());

                // then get the login result
                var loginResult = await tvDbClient.LoginAsync(new() { Apikey = Configuration.GetValue<string>(MediathekArr.Constants.ConfigurationConstants.TvdbApiKey), });

                // On success, store new Token. Else throw an exception
                if (loginResult.Status == "success")
                {
                    Token = loginResult.Data.Token;
                    Logger.LogTrace("Acquired Bearer Token: {BearerToken}", Token);
                }
                else
                {
                    Logger.LogError("Failed getting Bearer Token");
                    throw new Exception("Failed getting Bearer Token");
                }
            }
            return Token;
        }

        /// <summary>
        /// Inject Token into Send pipeline
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await AcquireToken();
            request.Headers.Authorization = new Headers.AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
        #endregion
    }
}