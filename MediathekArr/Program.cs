using CommunityToolkit.Diagnostics;
using Hangfire;
using Hangfire.PostgreSql;
using MediathekArr.Handler;
using MediathekArr.Infrastructure;
using MediathekArr.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Add Memory Cache to reduce load on Downstream */
builder.Services.AddMemoryCache();

/* Add Response Caching to reduce load on Downstream APIs */
builder.Services.AddResponseCaching();

/* Pull up SQLite Database */
builder.Services.AddDbContextFactory<MediathekArrContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString(MediathekArr.Constants.ConfigurationConstants.MediathekArrConnectionString);
    Guard.IsNotNullOrEmpty(connectionString, nameof(connectionString));
    options.UseSqlite(connectionString);
}, ServiceLifetime.Scoped);
// TODO: We need to run migrations in app.Use() once we start using migrations to update the DB schema
// TODO: TVDB recommends to pull the whole DB into a local copy. Maybe we do an initial seeding? And then run hangfire to periodically update the local copy?

/* Add Hangfire to schedule Downloads as a background task */
builder.Services.AddHangfire(config =>
{
    config.UsePostgreSqlStorage(c =>
    {
        c.UseNpgsqlConnection(builder.Configuration.GetConnectionString("postgres"));
    });
});

/* Set up the HTTP Client for HttpClientFactory */
builder.Services.AddHttpClient(MediathekArr.Constants.HttpClientNameConstants.MediathekArrClient, client =>
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

builder.Services.AddScoped<MediathekSearchService>();
builder.Services.AddScoped<ItemLookupService>();
builder.Services.AddScoped<DownloadService>();


var app = builder.Build();

app.MapDefaultEndpoints();

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
    app.UseHangfireDashboard();
}

/* Use Response Caching to avoid querying Downstream APIs too often */
app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/* Park this here for Unit Test support */
public partial class Program;