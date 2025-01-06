using MediathekArrApi.Infrastructure;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediathekArrApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TvdbController : Controller
{
    private readonly MediathekArrContext _context;
    private readonly HttpClient _httpClient;

    public TvdbController(MediathekArrContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    [HttpGet("token")]
    public async Task<IActionResult> GetToken()
    {
        var tokenEntry = await _context.ApiTokens.FirstOrDefaultAsync(t => t.Id == 1);

        if (tokenEntry != null && tokenEntry.ExpirationDate > DateTime.UtcNow)
        {
            return Ok(tokenEntry.Token);
        }
        else
        {
            var apiKey = await GetApiKey();
            if (apiKey == null)
            {
                return BadRequest("API key not found.");
            }

            var newToken = await RefreshToken(apiKey);
            if (newToken == null)
            {
                return StatusCode(500, "Failed to refresh token.");
            }

            return Ok(newToken);
        }
    }

    private async Task<string> GetApiKey()
    {
        var apiKeyEntry = await _context.ApiKeys.FirstOrDefaultAsync(k => k.Id == 1);
        return apiKeyEntry?.Key;
    }

    private async Task<string> RefreshToken(string apiKey)
    {
        var requestContent = new StringContent(JsonSerializer.Serialize(new { apikey = apiKey }), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api4.thetvdb.com/v4/login", requestContent);

        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<TvdbApiResponse>(responseData);

            if (data != null && data.Status == "success")
            {
                var token = data.Data.Token;
                var expirationDate = DateTime.UtcNow.AddHours(24); // Assuming token expires after 24 hours

                var tokenEntry = await _context.ApiTokens.FirstOrDefaultAsync(t => t.Id == 1);
                if (tokenEntry != null)
                {
                    _context.ApiTokens.Remove(tokenEntry);
                }

                _context.ApiTokens.Add(new ApiToken { Id = 1, Token = token, ExpirationDate = expirationDate });
                await _context.SaveChangesAsync();

                return token;
            }
        }

        return null;
    }
}

public class TvdbApiResponse
{
    public string Status { get; set; }
    public TvdbApiData Data { get; set; }
}

public class TvdbApiData
{
    public string Token { get; set; }
}