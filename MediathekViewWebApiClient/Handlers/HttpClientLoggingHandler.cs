using Microsoft.Extensions.Logging;

namespace System.Net.Http;

/// <summary>
/// Logging Handler for HttpClient
/// </summary>
/// <param name="logger"></param>
public class HttpClientLoggingHandler(ILogger<HttpClientLoggingHandler> logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Start processing HTTP request {Method} {Url}", request.Method, request.RequestUri);
        var response = await base.SendAsync(request, cancellationToken);
        logger.LogInformation("Finished processing HTTP request {Method} {Url}", request.Method, request.RequestUri);
        return response;
    }
}