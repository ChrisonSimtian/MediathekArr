using Microsoft.Extensions.Caching.Memory;

namespace MediathekArr.Factories;

/// <summary>
/// Create <see cref="MemoryCacheOptions"/>
/// </summary>
public static class MemoryCacheEntryOptionsFactory
{
    /// <summary>
    /// Default <see cref="MemoryCacheOptions"/>
    /// </summary>
    public static MemoryCacheEntryOptions Default => new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(Constants.CacheConstants.AbsoluteExpiration),
        SlidingExpiration = TimeSpan.FromMinutes(Constants.CacheConstants.SlidingExpiration)
    };
}