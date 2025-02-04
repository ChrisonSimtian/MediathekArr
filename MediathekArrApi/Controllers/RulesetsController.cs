using MediathekArr.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MediathekArr.Models.Rulesets;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<List<Ruleset>>> Get() => await context.Rulesets.ToListAsync();

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