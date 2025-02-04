using System.Text.Json.Serialization;
using MediathekArr.Infrastructure;
using MediathekArr.Models.Rulesets;
using MediathekArr.Models.Tvdb;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Scalar.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    /// <summary>
    /// Configure MediathekArr API
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IConfigurationBuilder AddMediathekArrApi(this IConfigurationBuilder builder)
    {
        return builder;
    }

    /// <summary>
    /// Set up Services for MediathekArr API
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder AddMediathekArrApi(this WebApplicationBuilder builder)
    {
        builder.Logging.AddMediathekArrLogger();

        #region Caching
        builder.Services.AddMemoryCache();
        /* Caching architecture:
         * Ideally we build up some form of caching across all components. There are basically two different types of caching,
         * internal caching within the application and outgoing caching to the client.
         * 
         * Internal Caching:
         * https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-9.0
         * 
         * Output Caching:
         * https://learn.microsoft.com/en-us/aspnet/core/performance/caching/overview?view=aspnetcore-9.0#output-caching
         * https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?view=aspnetcore-9.0
         * https://learn.microsoft.com/en-us/aspnet/core/performance/caching/middleware?view=aspnetcore-9.0
         * 
         * Distributed Cache:
         * https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed?view=aspnetcore-9.0
         * https://github.com/leonibr/community-extensions-cache-postgres
         * https://github.com/neosmart/SqliteCache
         * 
         * Hybrid Cache (Still in Preview, combines local and distributed cache):
         * https://learn.microsoft.com/en-us/aspnet/core/performance/caching/hybrid?view=aspnetcore-9.0
         */
        #endregion

        #region Database
        /* Add DbContext with specific DB Implementation 
         * Uncomment whatever Database you want to use and comment the other one(s) out :-)
         */

        /* Postgres SQL */
        //builder.Services.AddDbContext<MediathekArrContext>(options => options.UseNpgsql("Host=localhost;Database=tvdb_cache;Username=yourusername;Password=yourpassword"));

        /* SQLite */
        builder.Services.AddDbContext<MediathekArrContext>(options => options.UseSqlite("Data Source=tvdb_cache.sqlite"));
        #endregion

        #region TVDB Client
        /* Spin up the TVDB Client */
        var config = builder.Configuration.AddTvdbClient().Build();
        builder.Services.AddTvdbClient(config);
        #endregion

        /* Set up Controllers */
        builder.Services.AddControllers()
        /* Prevent circular endless loops */
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        })
        ;

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        return builder;
    }

    /// <summary>
    /// Start MediathekArr API
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    /// <remarks>Runs DB migrations</remarks>
    public static IApplicationBuilder UseMediathekArrApi(this WebApplication app)
    {
        /* Run migrations for existing Databases */
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MediathekArrContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        int migrationCount = context.Database.GetPendingMigrations().Count();
        if (migrationCount > 0)
        {
            logger.LogInformation("Found {count} Migrations. Running Migrations now.", migrationCount);
            try
            {
                context.Database.Migrate();
                logger.LogInformation("Migrations completed.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to run Migrations.");
            }
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            /* Open API definitions */
            app.MapOpenApi();
            app.MapScalarApiReference();

            /* Error Handling */
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
