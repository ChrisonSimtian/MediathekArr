using System.Net.Mime;
using Chrison.Extensions;
using MediathekViewWeb.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    /// <summary>
    /// Configure MediathekViewWebApiClient
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IConfigurationBuilder AddMediathekViewWebApiClient(this IConfigurationBuilder builder)
    {
        var config = builder
            .AddJsonFile("MediathekViewWebApiClientConfig.json", optional: true)
            .Build();

        return builder;
    }

    /// <summary>
    /// Set up Services for MediathekViewWebApiClient
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IServiceCollection AddMediathekViewWebApiClient(this IServiceCollection builder, IConfiguration config)
    {
        builder.Configure<MediathekViewWebConfiguration>(config.GetRequiredSection("MediathekViewWebConfiguration"));
        string baseUrl = config.GetValue<string>("MediathekViewWebConfiguration:BaseUrl") ?? "https://mediathekviewweb.de/api/";
        builder
            .AddHttpClient(MediathekViewWeb.Constants.MediathekViewWebConstants.HttpClientName, client =>
            {
                client.BaseAddress = new Uri(baseUrl.EnsureTrailingSlash());
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:131.0) Gecko/20100101 Firefox/131.0");
                client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip");
                client.DefaultRequestHeaders.Accept.ParseAdd(MediaTypeNames.Application.Json);
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            })
            /* Add sensitive query parameters to log output */
            .AddHttpMessageHandler<HttpClientLoggingHandler>()
            ;

        builder.TryAddTransient<HttpClientLoggingHandler>();

        /* Inject all Tvdb Clients at once */
        builder.Scan(scan => scan
        .FromCallingAssembly()
        .AddClasses(classes => classes.AssignableTo<MediathekViewWeb.Clients.IApiClient>())
        .AsMatchingInterface()
        .AsHttpClient(MediathekViewWeb.Constants.MediathekViewWebConstants.HttpClientName)
        );

        return builder;
    }
}