using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Data.Sqlite;
namespace MediathekArr.Controllers;
public class TokenManager
{
    private static readonly HttpClient client = new HttpClient();

    public static string GetToken(SqliteConnection db)
    {
        // Check if token is stored and still valid
        using (var cmd = new SqliteCommand("SELECT token, expiration_date FROM api_token WHERE id = 1", db))
        {
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string token = reader.GetString(0);
                    DateTime expirationDate = reader.GetDateTime(1);

                    if (DateTime.Now < expirationDate)
                    {
                        return token;
                    }
                }
            }
        }

        // If no valid token, refresh the token
        string apiKey = GetApiKey(db);
        return RefreshToken(db, apiKey);
    }

    private static string RefreshToken(SqliteConnection db, string apiKey)
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { apikey = apiKey }), Encoding.UTF8, "application/json");

        var response = client.PostAsync("https://api4.thetvdb.com/v4/login", content).Result;
        var responseString = response.Content.ReadAsStringAsync().Result;
        var data = JObject.Parse(responseString);

        if (data["status"]?.ToString() == "success")
        {
            string token = data["data"]["token"].ToString();
            DateTime expirationDate = DateTime.Now.AddDays(1); // Assuming token expires after 24 hours

            // Update or insert the new token and expiration into the api_token table
            using (var cmd = new SqliteCommand("DELETE FROM api_token WHERE id = 1", db))
            {
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SqliteCommand("INSERT INTO api_token (id, token, expiration_date) VALUES (1, @token, @expiration_date)", db))
            {
                cmd.Parameters.AddWithValue("@token", token);
                cmd.Parameters.AddWithValue("@expiration_date", expirationDate);
                cmd.ExecuteNonQuery();
            }

            return token;
        }
        else
        {
            // Handle error or retry logic
            return null;
        }
    }

    private static string GetApiKey(SqliteConnection db)
    {
        // Implement this method to retrieve the API key from the database
        throw new NotImplementedException();
    }
}

