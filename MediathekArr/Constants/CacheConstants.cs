namespace MediathekArr.Constants;

public static class CacheConstants
{
    /// <summary>
    /// Http Response Cache Duration in Seconds
    /// </summary>
    public const int ResponseCacheDuration = 60;

    /// <summary>
    /// Absolute Expiration of In Memory cache starting from now
    /// </summary>
    public const int AbsoluteExpiration = 5;

    /// <summary>
    /// Sliding Expiration of In Memory cache
    /// </summary>
    public const int SlidingExpiration = 2;
}
