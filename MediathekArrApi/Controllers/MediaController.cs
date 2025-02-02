using MediathekArr.Infrastructure;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tvdb.Clients;
using Tvdb.Types;
using MediathekArr.Extensions;
using System.Net;
using Tvdb.Extensions;
using Microsoft.Extensions.Caching.Memory;
using MediathekArr.Models.Tvdb;
using MediathekArr.Exceptions;
using MediathekArr.Models.Rulesets;

namespace MediathekArr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediaController(ILogger<MediaController> logger, MediathekArrContext context, IMemoryCache memoryCache) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<Media>>> GetAsync()
    {
        var result = await context.Media.ToListAsync();
        logger.LogTrace("Found {count} Results", result.Count);
        return Ok(result);
    }
}