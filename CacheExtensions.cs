using CachingApp.Cache;
using CachingApp.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CachingApp;

public static class CacheExtensions
{
    public static IServiceCollection AddCachingConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentException(nameof(services));
        if (configuration == null) throw new ArgumentException(nameof(configuration));

        var cacheConfiguration = configuration.GetSection("Caching").GetChildren();
        Dictionary<string, TimeSpan> configurationCache = cacheConfiguration.ToDictionary(child => child.Key, child => TimeSpan.Parse(child.Value));

        services.AddMemoryCache();
        services.AddSingleton<ICacheStore>(x => new CacheStore(x.GetService<IMemoryCache>(), configurationCache));

        return services;
    }
}
