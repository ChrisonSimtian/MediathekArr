using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediathekViewWeb.Models;

namespace MediathekViewWeb.Clients;

public class QueryClient : IApiClient
{
    private readonly HttpClient _httpClient;

    public QueryClient(HttpClient httpClient, Configuration.MediathekViewWebConfiguration configuration)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri(configuration.BaseUrl ?? "https://mediathekviewweb.de/api/");
    }

    /// <summary>
    /// Sends a query to the MediathekViewWeb API.
    /// </summary>
    /// <param name="query">The JSON query as a string.</param>
    /// <returns>The API response as a JSON string.</returns>
    public async Task<ApiResponse> QueryAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Query cannot be null or empty.", nameof(query));
        }

        var content = new StringContent(query, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("query", content);

        response.EnsureSuccessStatusCode(); // Throws if the status code is not successful

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ApiResponse>(responseContent);
    }

    /// <summary>
    /// Sends a query to the MediathekViewWeb API with a structured query object.
    /// </summary>
    /// <param name="query">The query object.</param>
    /// <returns>The API response as a JSON string.</returns>
    public async Task<ApiResponse> QueryAsync(object query)
    {
        var jsonQuery = JsonSerializer.Serialize(query);
        return await QueryAsync(jsonQuery);
    }
}