using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediathekArr.Infrastructure;
using MediathekArr.Models.Rulesets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MediathekArr.Controllers;

public class MediaControllerUnitTests
{
    public MediaControllerUnitTests(ITestOutputHelper outputHelper)
    {
        OutputHelper = outputHelper;

        var builder = new HostApplicationBuilder();

        var config = builder.Configuration
            .AddTvdbClient()
            .Build();

        builder.Services.AddDbContext<MediathekArrContext>(options => options.UseSqlite("Data Source=tvdb_cache.sqlite"));

        builder.Services
            .AddLogging((builder) => builder.AddXUnit(OutputHelper))
            .AddTvdbClient(config);

        builder.Services.TryAddSingleton<MediaController>();

        ServiceProvider = builder.Services.BuildServiceProvider();

        var dbContext = ServiceProvider.GetRequiredService<MediathekArrContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

        Controller = ServiceProvider.GetRequiredService<MediaController>();
    }

    public ITestOutputHelper OutputHelper { get; }
    public ServiceProvider ServiceProvider { get; }
    public MediaController Controller { get; }
    public MediathekArrContext CreateContext() => ServiceProvider.GetRequiredService<MediathekArrContext>();

    [Fact]
    public void Get_ShouldReturnAllMediaRecords()
    {
        // Arrange
        using var context = CreateContext();
        var testMedia = new Media { Id = 1, Name = "Test Media" };
        context.Media.Add(testMedia);
        context.SaveChanges();

        // Act
        var result = Controller.Get().ToList();

        // Assert
        result.ShouldNotBeEmpty();
        result.ShouldHaveSingleItem();
        result.ShouldContain(x => x.Name == "Test Media");
    }

    [Fact]
    public async Task Post_ShouldAddNewMediaRecord()
    {
        // Arrange
        using var context = CreateContext();
        var newMedia = new Media { Id = 1, Name = "New Media" };

        // Act
        await Controller.Post(newMedia);

        // Assert
        var savedMedia = await context.Media.FirstOrDefaultAsync();
        savedMedia.ShouldNotBeNull();
        savedMedia.Name.ShouldBe("New Media");
    }

    [Fact]
    public async Task Put_ShouldUpdateExistingMediaRecord()
    {
        // Arrange
        using var context = CreateContext();
        var existingMedia = new Media { Id = 1, Name = "Original Title" };
        context.Media.Add(existingMedia);
        await context.SaveChangesAsync();

        existingMedia.Name = "Updated Title";

        // Act
        await Controller.Put(existingMedia);

        // Assert
        var updatedMedia = await context.Media.FindAsync(1);
        updatedMedia.ShouldNotBeNull();
        updatedMedia.Name.ShouldBe("Updated Title");
    }

    [Fact]
    public async Task Delete_ShouldRemoveMediaRecord()
    {
        // Arrange
        using var context = CreateContext();
        var mediaToDelete = new Media { Id = 1, Name = "To Delete" };
        context.Media.Add(mediaToDelete);
        await context.SaveChangesAsync();

        // Act
        await Controller.Delete(mediaToDelete);

        // Assert
        var deletedMedia = await context.Media.FindAsync(1);
        deletedMedia.ShouldBeNull();
    }
}
