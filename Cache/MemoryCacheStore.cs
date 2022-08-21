﻿using CachingApp.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CachingApp.Cache;

public class MemoryCacheStore : ICacheStore
{
    private readonly IMemoryCache _memoryCache;
    private readonly Dictionary<string, TimeSpan> _expirationConfiguration;
    public MemoryCacheStore(
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

    public void Add<TItem>(TItem item, ICacheKey<TItem> key, DateTime? absoluteExpiration = null)
    {
        throw new NotImplementedException();
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
