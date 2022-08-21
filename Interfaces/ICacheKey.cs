namespace CachingApp.Interfaces;

public interface ICacheKey<TItem>
{
    string CacheKey { get; }
    string CacheName { get; }
}
