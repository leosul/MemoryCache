using CachingApp.Extensions;
using CachingApp.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CachingApp.Cache;

public class CacheStore : ICacheStore
{
    private readonly IMemoryCache _memoryCache;
    private readonly Dictionary<string, TimeSpan> _expirationConfiguration;
    public CacheStore(
        IMemoryCache memoryCache,
        Dictionary<string, TimeSpan> expirationConfiguration)
    {
        _memoryCache = memoryCache;
        this._expirationConfiguration = expirationConfiguration;
    }

    public void Add<TItem>(TItem item, ICacheKey<TItem> key, TimeSpan? expirationTime = null)
    {
        var cachedObjectName = key.CacheName;
        TimeSpan timespan;
        if (expirationTime.HasValue)
        {
            timespan = expirationTime.Value;
        }
        else
        {
            timespan = _expirationConfiguration[cachedObjectName];
        }

        this._memoryCache.Set(key.CacheKey, item, timespan);
    }

    public void Add<TItem>(TItem item, string cacheKey, TimeSpan? expirationTime = null)
    {
        TimeSpan timespan;
        if (expirationTime.HasValue)
        {
            timespan = expirationTime.Value;
        }
        else
        {
            timespan = _expirationConfiguration[cacheKey];
        }

        this._memoryCache.Set(HashHandler.GetHashCodeHandler(item), item, timespan);
    }

    public TItem Get<TItem>(ICacheKey<TItem> key) where TItem : class
    {
        if (this._memoryCache.TryGetValue(key.CacheKey, out TItem value))
        {
            return value;
        }

        return null;
    }

    public void Remove<TItem>(ICacheKey<TItem> key)
    {
        this._memoryCache.Remove(key.CacheKey);
    }
}
