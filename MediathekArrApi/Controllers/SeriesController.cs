using MediathekArrApi.Infrastructure;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediathekArrApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeriesController : Controller
{
    private readonly MediathekArrContext _context;
    private readonly HttpClient _httpClient;

    public SeriesController(MediathekArrContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    [HttpGet("{tvdbId}")]
    public async Task<IActionResult> GetSeriesData(int tvdbId, bool debug = false)
    {
        var apiKey = await GetApiKey();
        if (apiKey == null)
        {
            return BadRequest("API key not found.");
        }

        var seriesData = await _context.SeriesCaches
            .Include(s => s.Episodes)
            .FirstOrDefaultAsync(s => s.SeriesId == tvdbId);

        if (seriesData != null && !IsCacheExpired(seriesData))
        {
            return Ok(CreateResponse(seriesData, debug, true));
        }
        else
        {
            var newSeriesData = await FetchAndCacheSeriesData(tvdbId, apiKey, debug);
            if (newSeriesData == null)
            {
                return StatusCode(500, "Failed to fetch data from TVDB.");
            }

            return Ok(newSeriesData);
        }
    }

    private bool IsCacheExpired(SeriesCache seriesData)
    {
        return DateTime.UtcNow > seriesData.CacheExpiry;
    }

    private async Task<string> GetApiKey()
    {
        var apiKeyEntry = await _context.ApiKeys.FirstOrDefaultAsync(k => k.Id == 1);
        return apiKeyEntry?.Key;
    }

    private async Task<object> FetchAndCacheSeriesData(int tvdbId, string apiKey, bool debug)
    {
        var token = await GetToken(apiKey);
        if (token == null)
        {
            return null;
        }

        var response = await _httpClient.GetAsync($"https://api4.thetvdb.com/v4/series/{tvdbId}/extended?meta=episodes&short=true");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var responseData = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<SeriesApiResponse>(responseData);

        if (data == null || data.Status != "success")
        {
            return null;
        }

        var series = data.Data;
        var germanName = series.NameTranslations.ContainsKey("deu") ? series.NameTranslations["deu"] : series.Name;
        var germanAliases = series.Aliases?.Where(a => a.Language == "deu").ToList() ?? new List<Alias>();

        var cacheExpiry = DateTime.UtcNow.AddDays(6);
        if (series.LastUpdated.AddDays(7) > DateTime.UtcNow ||
            (series.NextAired.HasValue && series.NextAired.Value.AddDays(6) > DateTime.UtcNow) ||
            (series.LastAired.HasValue && series.LastAired.Value.AddDays(3) > DateTime.UtcNow))
        {
            cacheExpiry = DateTime.UtcNow.AddDays(2);
        }

        var seriesCache = new SeriesCache
        {
            SeriesId = tvdbId,
            Name = series.Name,
            GermanName = germanName,
            Aliases = JsonSerializer.Serialize(germanAliases),
            LastUpdated = series.LastUpdated,
            NextAired = series.NextAired,
            LastAired = series.LastAired,
            CacheExpiry = cacheExpiry,
            Episodes = series.Episodes.Select(e => new Episode
            {
                Id = e.Id,
                SeriesId = tvdbId,
                Name = e.Name,
                Aired = e.Aired,
                Runtime = e.Runtime,
                SeasonNumber = e.SeasonNumber,
                EpisodeNumber = e.Number
            }).ToList()
        };

        _context.SeriesCaches.RemoveRange(_context.SeriesCaches.Where(s => s.SeriesId == tvdbId));
        _context.SeriesCaches.Add(seriesCache);
        await _context.SaveChangesAsync();

        return CreateResponse(seriesCache, debug, false);
    }

    private async Task<string> GetToken(string apiKey)
    {
        var requestContent = new StringContent(JsonSerializer.Serialize(new { apikey = apiKey }), System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api4.thetvdb.com/v4/login", requestContent);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var responseData = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<SeriesApiResponse>(responseData);

        if (data == null || data.Status != "success")
        {
            return null;
        }

        var token = data.Data.Token;
        var expirationDate = DateTime.UtcNow.AddHours(24);

        var tokenEntry = await _context.ApiTokens.FirstOrDefaultAsync(t => t.Id == 1);
        if (tokenEntry != null)
        {
            _context.ApiTokens.Remove(tokenEntry);
        }

        _context.ApiTokens.Add(new ApiToken { Id = 1, Token = token, ExpirationDate = expirationDate });
        await _context.SaveChangesAsync();

        return token;
    }

    private object CreateResponse(SeriesCache seriesData, bool debug, bool cached)
    {
        var response = new
        {
            status = "success",
            data = new
            {
                id = seriesData.SeriesId,
                name = seriesData.Name,
                german_name = seriesData.GermanName,
                aliases = JsonSerializer.Deserialize<List<Alias>>(seriesData.Aliases),
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

        if (debug)
        {
            response = new
            {
                status = "success",
                data = new
                {
                    id = seriesData.SeriesId,
                    name = seriesData.Name,
                    german_name = seriesData.GermanName,
                    aliases = JsonSerializer.Deserialize<List<Alias>>(seriesData.Aliases),
                    episodes = seriesData.Episodes.Select(e => new
                    {
                        name = e.Name,
                        aired = e.Aired,
                        runtime = e.Runtime,
                        seasonNumber = e.SeasonNumber,
                        episodeNumber = e.EpisodeNumber
                    }).ToList()
                },
                debug = new
                {
                    cached,
                    cache_expiry = seriesData.CacheExpiry
                }
            };
        }

        return response;
    }
}



public class SeriesApiResponse
{
    public string Status { get; set; }
    public SeriesApiData Data { get; set; }
}

public class SeriesApiData
{
    public string Token { get; set; }
    public SeriesData Data { get; set; }
}

public class SeriesData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Dictionary<string, string> NameTranslations { get; set; }
    public List<Alias> Aliases { get; set; }
    public DateTime LastUpdated { get; set; }
    public DateTime? NextAired { get; set; }
    public DateTime? LastAired { get; set; }
    public List<EpisodeData> Episodes { get; set; }
}

public class Alias
{
    public string Name { get; set; }
    public string Language { get; set; }
}

public class EpisodeData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Aired { get; set; }
    public int Runtime { get; set; }
    public int SeasonNumber { get; set; }
    public int Number { get; set; }
}