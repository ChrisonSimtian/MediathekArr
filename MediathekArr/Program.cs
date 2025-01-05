using System.Diagnostics;
using System.Net;
using MediathekArr.Services;
using Scalar.AspNetCore;
using Yarp.ReverseProxy.Forwarder;

var builder = WebApplication.CreateBuilder(args);

/* Set up YARP to forward calls to /api to MediathekArr Server  */
builder.Services.AddHttpForwarder();

// Configure our own HttpMessageInvoker for outbound calls for proxy operations
var httpClient = new HttpMessageInvoker(new SocketsHttpHandler
{
    UseProxy = false,
    AllowAutoRedirect = false,
    AutomaticDecompression = DecompressionMethods.None,
    UseCookies = false,
    EnableMultipleHttp2Connections = true,
    ActivityHeadersPropagator = new ReverseProxyPropagator(DistributedContextPropagator.Current),
    ConnectTimeout = TimeSpan.FromSeconds(15),
});

// Setup our own request transform class
var transformer = HttpTransformer.Default;
var requestConfig = new ForwarderRequestConfig { ActivityTimeout = TimeSpan.FromSeconds(100) };


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddMemoryCache();
builder.Services.AddHttpClient("MediathekClient", client =>
{
    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:131.0) Gecko/20100101 Firefox/131.0");
    client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip");
    client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
});
builder.Services.AddSingleton<MediathekSearchService>();
builder.Services.AddSingleton<ItemLookupService>();
builder.Services.AddSingleton<DownloadService>();


var app = builder.Build();

// Middleware to log all incoming requests
app.Use(async (context, next) =>
{
    // Log the incoming request details
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    var request = context.Request;
    logger.LogInformation("Incoming Request: {method} {url}", request.Method, request.Path + request.QueryString);

    // Check if the request is a POST and has a body
    if (request.Method == HttpMethods.Post && request.ContentLength > 0)
    {
        // Enable buffering so the request can be read multiple times
        request.EnableBuffering();
    }

    // Call the next middleware in the pipeline
    await next.Invoke();
});

/* Redirect all calls to /api to MediathekArr Server */
app.Map("/api", async (HttpContext httpContext, IHttpForwarder forwarder) =>
{
    var error = await forwarder.SendAsync(httpContext, "http://localhost:5008", httpClient, requestConfig, transformer);

    /* Log failed forwarding */
    if(error != ForwarderError.None)
    {
        var errorFeature = httpContext.GetForwarderErrorFeature();
        var exception = errorFeature.Exception;
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogError("Failed forwarding request: {method} {url} {exception}", httpContext.Request.Method, httpContext.Request.Path + httpContext.Request.QueryString, exception.Message);
    }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
