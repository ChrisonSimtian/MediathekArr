using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TvdbClient.Configuration;
using TvdbClient.Handlers;
using TvdbClient.Models;

namespace TvdbClient.Provider;

public class TvdbTokenProvider(TvdbConfiguration options, ILogger<TvdbTokenProvider> logger) : ITokenProvider
{
    #region Properties
    public TvdbConfiguration Options { get; } = options;
    public ILogger<TvdbTokenProvider> Logger { get; } = logger;
    public Token Token { get; internal set; }
    #endregion

    #region Methods
    /// <inheritdoc/>
    public async Task<Token> AcquireTokenAsync(CancellationToken cancellationToken = default)
    {
        /* Refresh existing Token */
        if (Token is not null && Token.IsTokenExpired) await RefreshTokenAsync(cancellationToken);

        /* Acquire new Token */
        if (Token is null || Token.IsTokenExpired)
        {
            try
            {
                var httpClient = new HttpClient();
                var requestBody = new FormUrlEncodedContent(
                    [
                    new KeyValuePair<string, string>("apiKey", Options.ApiKey),
                    ]);

                var response = await httpClient.PostAsync(Options.TokenUrl, requestBody);
                if (!response.IsSuccessStatusCode) Logger.LogError("Failed acquiring Token");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
                var token = System.Text.Json.JsonSerializer.Deserialize<Token>(responseBody);
                if (token is null)
                {
                    Logger.LogError("Failed deserializing Token response");
                    throw new Exception("Failed deserializing Token response");
                }
                Token = token;
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed acquiring token. {errorMessage}", ex.Message);
                throw;
            }
        }

        return Token;
    }

    /// <inheritdoc/>
    public async Task RefreshTokenAsync(CancellationToken cancellationToken = default) => await AcquireTokenAsync(cancellationToken);
    #endregion
}