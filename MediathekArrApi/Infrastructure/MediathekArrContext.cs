using Microsoft.EntityFrameworkCore;

namespace MediathekArrApi.Infrastructure;

public class MediathekArrContext : DbContext
{
    public MediathekArrContext(DbContextOptions<MediathekArrContext> options) : base(options) { }

    public DbSet<ApiKey> ApiKeys { get; set; }
    public DbSet<ApiToken> ApiTokens { get; set; }
    public DbSet<SeriesCache> SeriesCaches { get; set; }
    public DbSet<Episode> Episodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiKey>().ToTable("api_key");
        modelBuilder.Entity<ApiToken>().ToTable("api_token");
        modelBuilder.Entity<SeriesCache>().ToTable("series_cache");
        modelBuilder.Entity<Episode>().ToTable("episodes");
    }
}