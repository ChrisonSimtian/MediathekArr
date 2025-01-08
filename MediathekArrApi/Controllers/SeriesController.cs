using MediathekArrApi.Infrastructure;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tvdb.Clients;
using Tvdb.Types;
using Tvdb.Models;
using MediathekArrApi.Models;
using System.Net.Mime;
using System.Net;

namespace MediathekArrApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeriesController : Controller
{
    private readonly MediathekArrContext _context;
    private readonly HttpClient _httpClient;
    private readonly ISeriesClient seriesClient;

    public SeriesController(MediathekArrContext context, HttpClient httpClient, ISeriesClient seriesClient)
    {
        _context = context;
        _httpClient = httpClient;
        this.seriesClient = seriesClient;
    }

    [HttpGet("{tvdbId}")]
    public async Task<IActionResult> GetSeriesData(int tvdbId, bool debug = false)
    {
        /* Return cached version of Series whenever possible */
        if(await _context.Series.AnyAsync(s => s.SeriesId == tvdbId))
        {
            var seriesData = await _context.Series
                .Include(s => s.Episodes)
                .FirstAsync(s => s.SeriesId == tvdbId);

            if (!IsCacheExpired(seriesData)) return Ok(CreateResponse(seriesData));
        }

        /* Fetch Series from TVDB API */
        var newSeriesData = await FetchAndCacheSeriesData(tvdbId);
        if (newSeriesData == null)
        {
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
        var seriesData = await seriesClient.ExtendedAsync(tvdbId, SeriesMeta.Episodes, true);

        if (!seriesData.IsSuccess) return null;

        /* Caching:
         * Place the record in our DB
         * TODO: Place a copy in the actual cache as well. Since this runs in a docker container, storing this in memory might actually boost performance :-)
         * TODO: Look into redis as cache instead of sqlite
         */
        var series = seriesData.Data;
        var germanName = series.NameTranslations.Any(t => t == "deu") ? series.NameTranslations.First(t => t == "deu") : series.Name;
        var germanAliases = series.Aliases.ToList()?.Where(a => a.Language == "deu").ToList();

        var cacheExpiry = DateTime.UtcNow.AddDays(6);
        if (series.LastUpdated.AddDays(7) > DateTime.UtcNow ||
            (series.NextAired.HasValue && series.NextAired.Value.AddDays(6) > DateTime.UtcNow) ||
            (series.LastAired.HasValue && series.LastAired.Value.AddDays(3) > DateTime.UtcNow))
        {
            cacheExpiry = DateTime.UtcNow.AddDays(2);
        }

        var record = new Series
        {
            SeriesId = tvdbId,
            Name = series.Name,
            GermanName = germanName,
            Aliases = JsonSerializer.Serialize(germanAliases),
            LastUpdated = series.LastUpdated,
            NextAired = series.NextAired,
            LastAired = series.LastAired,
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

        _context.Series.RemoveRange(_context.Series.Where(s => s.SeriesId == tvdbId));
        _context.Series.Add(record);
        await _context.SaveChangesAsync();
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
                aliases = JsonSerializer.Deserialize<List<MediathekArr.Models.Tvdb.Alias>>(seriesData.Aliases),
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



