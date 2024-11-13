using MediathekArr.Services;
using MediathekArr.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

/* Pull up SQLite Database */
builder.Services.AddDbContext<MediathekArrContext>();
// TODO: We need to run migrations in app.Use() once we start using migrations to update the DB schema
// TODO: TVDB recommends to pull the whole DB into a local copy. Maybe we do an initial seeding? And then run hangfire to periodically update the local copy?

/* Set up HTTP Client with support for Bearer Token */

/* Inject the TVDB Bearer Token handler as a Singleton (this way we can keep our Token once its generated) */
builder.Services.AddScoped<HttpClientHandler>();
builder.Services.AddTransient<TvdbBearerTokenHandler>();

/* Set up the HTTP Client for HttpClientFactory */
builder.Services.AddHttpClient(MediathekArr.Constants.HttpClientNameConstants.TvdbClient, client =>
{
    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:131.0) Gecko/20100101 Firefox/131.0");
    client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip");
    client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
})
    .AddHttpMessageHandler<TvdbBearerTokenHandler>()
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
    });

/* Register TVDB API Clients */
builder.Services.AddHttpClient<TVDB.SeriesClient>(MediathekArr.Constants.HttpClientNameConstants.TvdbClient);
builder.Services.AddHttpClient<TVDB.SearchClient>(MediathekArr.Constants.HttpClientNameConstants.TvdbClient);

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


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/* Park this here for Unit Test support */
public partial class Program { }