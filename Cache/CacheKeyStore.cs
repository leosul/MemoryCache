using CachingApp.Interfaces;

namespace CachingApp.Cache;

public class CacheKeyStore<T> : ICacheKey<T> where T : class
{
    public CacheKeyStore(string cacheKey, string cacheName)
    {
        CacheKey = cacheKey;
        CacheName = cacheName;
    }
    public string CacheKey { get; set; }
    public string CacheName { get; set; }
    public void CreateStore(string cacheKey, string cacheName)
    {
        CacheKey = $"{cacheName}_{cacheKey}";
        CacheName = cacheName;
    }
}
