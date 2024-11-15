using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using MediathekArr.Domain;
using MediathekArr.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TVDB;
using TVDB.Models;

namespace MediathekArr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeriesController(MediathekArrContext context, SeriesClient seriesClient, IMemoryCache cache) : ControllerBase
{
    #region Properties
    public MediathekArrContext Context { get; } = context;
    public SeriesClient SeriesClient { get; } = seriesClient;
    public IMemoryCache Cache { get; } = cache;
    #endregion

    /// <summary>
    /// Fetch Series Information
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [ResponseCache(Duration = Constants.CacheConstants.ResponseCacheDuration)]
    public async Task<IActionResult> GetSeriesData([FromQuery]int id)
    {
        try
        {
            if(!Cache.TryGetValue(id, out Series? seriesData))
            {
                bool existsInDatabase = await Context.SeriesCache.AnyAsync(r => r.SeriesId == id);
                if (!existsInDatabase) await GetSeriesDataFromTVDB(id);

                /* Fetch from Database */
                seriesData = await Context.SeriesCache.FirstAsync(r => r.SeriesId == id);

                Cache.Set(id, seriesData, Factories.MemoryCacheEntryOptionsFactory.Default);
            }
            
            // Return cached data if available and not expired
            var episodes = await Context.Episodes.Where(r => r.Series.SeriesId == id).ToListAsync();

            var response = new
            {
                status = "success",
                data = new
                {
                    id,
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

    /// <summary>
    /// Fetch Series Data from TVDB API
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ResponseCache(Duration = Constants.CacheConstants.ResponseCacheDuration)]
    public async Task<IActionResult> GetSeriesDataFromTVDB(int id)
    {
        // TODO: This needs refactoring as it returns IActionResult where instead it should just grab everything and return it plan
        try
        {
            var seriesResult = await SeriesClient.ExtendedAsync(id, Meta4.Episodes, true);

            if (seriesResult.Status != "success") return BadRequest(new { status = "error", message = "Failed to fetch data from TVDB" });

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
        catch (ApiException)
        {
            return BadRequest(new { status = "error", message = "Failed to retrieve valid token from TVDB" });
        }
    }
}