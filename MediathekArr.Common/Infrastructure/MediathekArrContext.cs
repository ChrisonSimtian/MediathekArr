using Microsoft.EntityFrameworkCore;


namespace MediathekArr.Infrastructure;

public class MediathekArrContext(DbContextOptions<MediathekArrContext> options) : DbContext(options)
{
    public DbSet<Domain.Episode> Episodes { get; set; }
    public DbSet<Domain.Series> SeriesCache { get; set; }
    public DbSet<Domain.TvdbResponse> TvdbResponse { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=tvdb_cache.sqlite;Version=3;");
}
