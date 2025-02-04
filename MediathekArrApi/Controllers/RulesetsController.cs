using MediathekArr.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MediathekArr.Models.Rulesets;
using Microsoft.AspNetCore.OData.Query;

namespace MediathekArr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RulesetsController(ILogger<RulesetsController> logger, MediathekArrContext context, IMemoryCache memoryCache) : Controller
{
    /// <summary>
    /// Get all Ruleset Records
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [EnableQuery]
    public IQueryable<Ruleset> Get() => context.Rulesets;

    /// <summary>
    /// Create new Ruleset record
    /// </summary>
    /// <param name="ruleset"></param>
    [HttpPost]
    public async Task Post([FromBody] Ruleset ruleset)
    {
        context.Rulesets.Add(ruleset);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Update Ruleset record
    /// </summary>
    /// <param name="ruleset"></param>
    [HttpPut]
    public async Task Put([FromBody] Ruleset ruleset)
    {
        context.Rulesets.Update(ruleset);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Delete Ruleset record
    /// </summary>
    /// <param name="ruleset"></param>
    [HttpDelete]
    public async Task Delete([FromBody] Ruleset ruleset)
    {
        context.Rulesets.Remove(ruleset);
        await context.SaveChangesAsync();
    }
}