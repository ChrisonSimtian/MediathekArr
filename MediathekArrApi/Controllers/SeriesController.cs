using MediathekArr.Infrastructure;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tvdb.Clients;
using Tvdb.Types;
using Tvdb.Models;
using MediathekArr.Extensions;
using System.Net;
using Tvdb.Extensions;

namespace MediathekArr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeriesController(MediathekArrContext context, ISeriesClient seriesClient, ILogger<SeriesController> logger) : Controller
{
    #region Properties
    public MediathekArrContext Context { get; } = context;
    public ISeriesClient SeriesClient { get; } = seriesClient;

    public ILogger<SeriesController> Logger { get; } = logger;
    #endregion


    [HttpGet("{tvdbId}")]
    public async Task<IActionResult> GetSeriesData(int tvdbId)
    {
        /* Return cached version of Series whenever possible */
        if (await Context.Series.AnyAsync(s => s.SeriesId == tvdbId))
        {
            Logger.LogTrace("Found {tvdbId} in Cache", tvdbId);
            var seriesData = await Context.Series
                .Include(s => s.Episodes)
                .FirstAsync(s => s.SeriesId == tvdbId);

            if (!seriesData.CacheExpiry.IsInThePast()) return Ok(CreateResponse(seriesData));
            Logger.LogWarning("Series {tvdbId} in Cache has expired on {expiryDate}", tvdbId, seriesData.CacheExpiry);
        }

        /* Fetch Series from TVDB API */
        var newSeriesData = await FetchAndCacheSeriesData(tvdbId);
        if (newSeriesData == null)
        {
            Logger.LogError("Tried fetching Series {tvdbId} from TVDB and failed.", tvdbId);
            return Problem(statusCode: (int)HttpStatusCode.InternalServerError, title: "Failed to fetch data from TVDB.", detail: $"Tried fetching Series {tvdbId} from TVDB and failed.");
        }

        return Ok(CreateResponse(newSeriesData));
    }

    private bool IsCacheExpired(Series seriesData)
    {
        return DateTime.UtcNow > seriesData.CacheExpiry;
    }

    private async Task<Series> FetchAndCacheSeriesData(int tvdbId)
    {
        /* Fetch from TVDB */
        var seriesData = await SeriesClient.ExtendedAsync(tvdbId, SeriesMeta.Episodes, true);
        if (!seriesData.IsSuccess) return null;

        /* Caching:
         * Place the record in our DB
         * TODO: Place a copy in the actual cache as well. Since this runs in a docker container, storing this in memory might actually boost performance :-)
         * TODO: Look into redis as cache instead of sqlite
         */
        var series = seriesData.Data;
        var germanName = series.NameTranslations.Any(t => t == "deu") ? series.NameTranslations.First(t => t == "deu") : series.Name;
        var germanAliases = series.Aliases.ToList()?.Where(a => a.Language == "deu").ToList();

        /* Set Cache expiry */
        var cacheExpiry = DateTime.UtcNow.AddDays(6);
        if ((series.LastUpdated.HasValue && series.LastUpdated.Value.AddDays(7) > DateTime.UtcNow) ||
            (series.NextAired.HasValue && series.NextAired.Value.ToDateTime().AddDays(6) > DateTime.UtcNow) ||
            (series.LastAired.HasValue && series.LastAired.Value.ToDateTime().AddDays(3) > DateTime.UtcNow))
        {
            cacheExpiry = DateTime.UtcNow.AddDays(2);
        }

        var record = new Series
        {
            SeriesId = tvdbId,
            Name = series.Name,
            GermanName = germanName,
            Aliases = JsonSerializer.Serialize(germanAliases),
            LastUpdated = series.LastUpdated ?? DateTime.MinValue,
            NextAired = series.NextAired.ToDateTime(),
            LastAired = series.LastAired.ToDateTime(),
            CacheExpiry = cacheExpiry,
            Episodes = [.. series.Episodes.Select(e => new Episode
            {
                Id = e.Id,
                SeriesId = tvdbId,
                Name = e.Name,
                Aired = e.Aired,
                Runtime = e.Runtime,
                SeasonNumber = e.SeasonNumber,
                EpisodeNumber = e.Number
            })]
        };

        Context.Series.RemoveRange(Context.Series.Where(s => s.SeriesId == tvdbId));
        await Context.Series.AddAsync(record);
        await Context.SaveChangesAsync();
        return record;
    }

    private static ApiResponseWrapper<object> CreateResponse(Series seriesData)
    {
        var response = new ApiResponseWrapper<object>()
        {
            Status = "success",
            Data = new
            {
                id = seriesData.SeriesId,
                name = seriesData.Name,
                german_name = seriesData.GermanName,
                aliases = JsonSerializer.Deserialize<List<Models.Tvdb.Alias>>(seriesData.Aliases),
                episodes = seriesData.Episodes.Select(e => new
                {
                    name = e.Name,
                    aired = e.Aired,
                    runtime = e.Runtime,
                    seasonNumber = e.SeasonNumber,
                    episodeNumber = e.EpisodeNumber
                }).ToList()
            }
        };

        return response;
    }
}



