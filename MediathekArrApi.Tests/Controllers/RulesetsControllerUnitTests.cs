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

public class RulesetsControllerUnitTests
{
    public RulesetsControllerUnitTests(ITestOutputHelper outputHelper)
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

        builder.Services.TryAddSingleton<RulesetsController>();

        ServiceProvider = builder.Services.BuildServiceProvider();

        var dbContext = ServiceProvider.GetRequiredService<MediathekArrContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

        Controller = ServiceProvider.GetRequiredService<RulesetsController>();
    }

    public ITestOutputHelper OutputHelper { get; }
    public ServiceProvider ServiceProvider { get; }
    public RulesetsController Controller { get; }
    public MediathekArrContext CreateContext() => ServiceProvider.GetRequiredService<MediathekArrContext>();

    [Fact]
    public void Get_ShouldReturnAllRulesets()
    {
        // Arrange
        using var context = CreateContext();
        context.Rulesets.Add(new Ruleset { Id = 1, Topic = "Test Ruleset 1" });
        context.Rulesets.Add(new Ruleset { Id = 2, Topic = "Test Ruleset 2" });
        context.SaveChanges();

        // Act
        var result = Controller.Get().ToList();

        // Assert
        result.Count.ShouldBe(2);
        result.ShouldContain(x => x.Topic == "Test Ruleset 1");
        result.ShouldContain(x => x.Topic == "Test Ruleset 2");
    }

    [Fact]
    public async Task Post_ShouldCreateNewRuleset()
    {
        // Arrange
        using var context = CreateContext();
        var newRuleset = new Ruleset { Id = 1, Topic = "New Ruleset" };

        // Act
        await Controller.Post(newRuleset);

        // Assert
        var createdRuleset = await context.Rulesets.FindAsync(1);
        createdRuleset.ShouldNotBeNull();
        createdRuleset.Topic.ShouldBe("New Ruleset");
    }

    [Fact]
    public async Task Put_ShouldUpdateExistingRuleset()
    {
        // Arrange
        using var context = CreateContext();
        var ruleset = new Ruleset { Id = 1, Topic = "Original Name" };
        context.Rulesets.Add(ruleset);
        await context.SaveChangesAsync();

        ruleset.Topic = "Updated Name";

        // Act
        await Controller.Put(ruleset);

        // Assert
        var updatedRuleset = await context.Rulesets.FindAsync(1);
        updatedRuleset.ShouldNotBeNull();
        updatedRuleset.Topic.ShouldBe("Updated Name");
    }

    [Fact]
    public async Task Delete_ShouldRemoveRulesetRecord()
    {
        // Arrange
        using var context = CreateContext();
        var rulesetToDelete = new Ruleset { Id = 1, Topic = "To Delete" };
        context.Rulesets.Add(rulesetToDelete);
        await context.SaveChangesAsync();

        // Act
        await Controller.Delete(rulesetToDelete);

        // Assert
        var deletedRuleset = await context.Rulesets.FindAsync(1);
        deletedRuleset.ShouldBeNull();
    }
}