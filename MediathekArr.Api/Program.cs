using CommunityToolkit.Diagnostics;
using MediathekArr.Handler;
using MediathekArr.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/* Park this here for Unit Test support */
public partial class Program;