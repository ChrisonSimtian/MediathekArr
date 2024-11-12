using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MediathekArr.Domain;
using MediathekArr.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Tvdb.Sdk;

namespace MediathekArr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeriesController : ControllerBase
{
    public MediathekArrContext dbContext { get; }
    public HttpClient HttpClient { get; }
    public string ApiKey { get; }

    public ILoginClient LoginClient { get; }
    public SdkClientSettings SdkClientSettings { get; }
    public ISearchClient SearchClient { get; }
    public TVDB.TvdbClient TvdbClient { get; }

    public SeriesController(HttpClient httpClient, IConfiguration configuration, ILoginClient loginClient, SdkClientSettings sdkClientSettings, ISearchClient searchClient, TVDB.TvdbClient tvdbClient)
    {
        dbContext = new MediathekArrContext();
        HttpClient = httpClient;
        LoginClient = loginClient;
        SdkClientSettings = sdkClientSettings;
        SearchClient = searchClient;
        TvdbClient = tvdbClient;
        ApiKey = configuration["TvDbApiKey"];
    }

    // Helper function to determine if cache is expired
    private bool IsCacheExpired(DateTime cacheExpiry) => DateTime.Now > cacheExpiry;

    // Main function to fetch series information
    [HttpGet("{tvdbId}")]
    public async Task<IActionResult> GetSeriesData(int tvdbId, bool debug = false)
    {
        try
        {
            bool cached = await dbContext.SeriesCache.AnyAsync(r => r.SeriesId == tvdbId);

            if(!cached) await FetchAndCacheSeriesData(tvdbId, debug);

            // Fetch from cache
            var seriesData = await dbContext.SeriesCache.FirstAsync(r => r.SeriesId == tvdbId);

            // Return cached data if available and not expired
            var episodes = await dbContext.Episodes.Where(r => r.Series.SeriesId == tvdbId).ToListAsync();

            var response = new
            {
                status = "success",
                data = new
                {
                    id = tvdbId,
                    name = seriesData.Name,
                    german_name = seriesData.GermanName,
                    aliases = JsonSerializer.Deserialize<string[]>(seriesData.Aliases),
                    episodes = episodes.Select(e => new
                    {
                        name = e.Name,
                        aired = e.Aired,
                        runtime = e.Runtime,
                        seasonNumber = e.SeasonNumber,
                        episodeNumber = e.EpisodeNumber
                    })
                }
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(new { status = "error", message = $"Error retrieving series data: {e.Message}" });
        }
    }

    // Function to fetch and cache data from TVDB
    private async Task<IActionResult> FetchAndCacheSeriesData(int tvdbId, bool debug = false)
    {
        try
        {
            var loginResult = await TvdbClient.LoginAsync(new TVDB.Body
            {
                Apikey = ApiKey,
            });

            // TODO: Inject bearer token
            var seriesResult = await TvdbClient.GetSeriesExtendedAsync(tvdbId, TVDB.Meta4.Episodes, true);

            if(seriesResult.Status != "success") return BadRequest(new { status = "error", message = "Failed to fetch data from TVDB" });

            var data = new TvdbResponse
            {
                Data = seriesResult,
                Status = "success",
            };

            if (data?.Status != "success")
            {
                return BadRequest(new { status = "error", message = "Failed to fetch data from TVDB" });
            }

            return Ok(data);
        }
        catch (LoginException)
        {
            return BadRequest(new { status = "error", message = "Failed to retrieve valid token from TVDB" });
        }
    }

    // TODO: Implement GetToken method
}