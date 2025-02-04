using MediathekArr.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MediathekArr.Models.Rulesets;
using Microsoft.AspNetCore.OData.Query;

namespace MediathekArr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediaController(ILogger<MediaController> logger, MediathekArrContext context, IMemoryCache memoryCache) : Controller
{
    /// <summary>
    /// Get all Media Records
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [EnableQuery]
    public IQueryable<Media> Get() => context.Media;

    /// <summary>
    /// Create new Media record
    /// </summary>
    /// <param name="media"></param>
    [HttpPost]
    public async Task Post([FromBody] Media media)
    {
        context.Media.Add(media);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Update Media record
    /// </summary>
    /// <param name="media"></param>
    [HttpPut]
    public async Task Put([FromBody] Media media)
    {
        context.Media.Update(media);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Delete Media record
    /// </summary>
    /// <param name="media"></param>
    [HttpDelete]
    public async Task Delete([FromBody] Media media)
    {
        context.Media.Remove(media);
        await context.SaveChangesAsync();
    }
}