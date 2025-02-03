using MediathekArr.Models.Tvdb;
using Microsoft.EntityFrameworkCore;

namespace MediathekArr.Infrastructure;

public class MediathekArrContext : DbContext
{
    public MediathekArrContext(DbContextOptions<MediathekArrContext> options) : base(options) { }

    public DbSet<Series> Series { get; set; }
    public DbSet<Episode> Episodes { get; set; }

    // public DbSet<Models.Rulesets.Ruleset> Rulesets { get; set; }
    // public DbSet<Models.Rulesets.Media> Media { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}