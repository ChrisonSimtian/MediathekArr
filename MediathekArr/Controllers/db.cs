using System;
using System.IO;
using System.Web;
using Microsoft.Data.Sqlite;
namespace MediathekArr.Controllers;
public class DatabaseManager
{
    private const string DB_FILE = "tvdb_cache.sqlite";

    public static SqliteConnection InitializeDatabase()
    {
        bool isFirstRun = !File.Exists(DB_FILE);

        var db = new SqliteConnection($"Data Source={DB_FILE};Version=3;");
        db.Open();

        if (isFirstRun)
        {
            CreateTables(db);
        }

        return db;
    }

    private static void CreateTables(SqliteConnection db)
    {
        string createApiKeyTableQuery = @"CREATE TABLE IF NOT EXISTS api_key (
            id INTEGER PRIMARY KEY,
            key TEXT NOT NULL
        )";

        string createTokenTableQuery = @"CREATE TABLE IF NOT EXISTS api_token (
            id INTEGER PRIMARY KEY,
            token TEXT NOT NULL,
            expiration_date TEXT NOT NULL
        )";

        string createSeriesCacheTableQuery = @"CREATE TABLE IF NOT EXISTS series_cache (
            series_id INTEGER PRIMARY KEY,
            name TEXT,
            german_name TEXT,
            aliases TEXT,
            last_updated TEXT,
            next_aired TEXT,
            last_aired TEXT,
            cache_expiry TEXT
        )";

        string createEpisodesTableQuery = @"CREATE TABLE IF NOT EXISTS episodes (
            id INTEGER PRIMARY KEY,
            series_id INTEGER,
            name TEXT,
            aired TEXT,
            runtime INTEGER,
            season_number INTEGER,
            episode_number INTEGER,
            FOREIGN KEY(series_id) REFERENCES series_cache(series_id)
        )";

        using var cmd = new SqliteCommand(db.ConnectionString);
        cmd.CommandText = createApiKeyTableQuery;
        cmd.ExecuteNonQuery();

        cmd.CommandText = createTokenTableQuery;
        cmd.ExecuteNonQuery();

        cmd.CommandText = createSeriesCacheTableQuery;
        cmd.ExecuteNonQuery();

        cmd.CommandText = createEpisodesTableQuery;
        cmd.ExecuteNonQuery();
    }

    public static string GetApiKey(SqliteConnection db)
    {
        using (var cmd = new SqliteCommand("SELECT key FROM api_key WHERE id = 1", db))
        {
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                return result.ToString();
            }
            else
            {
                // TODO: Find way to inject key (ENV variable?)
                return null;
            }
        }
    }
}

