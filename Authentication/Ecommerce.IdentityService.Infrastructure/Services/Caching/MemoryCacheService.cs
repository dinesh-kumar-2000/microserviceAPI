using Ecommerce.IdentityService.Application.Interfaces.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace Ecommerce.IdentityService.Infrastructure.Services.Caching;

public class MemoryCacheService : ICacheService
{
    private readonly IMemoryCache _cache;

    public MemoryCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> fetch, TimeSpan duration)
    {
        if (_cache.TryGetValue(key, out T value))
            return value;

        value = await fetch();

        _cache.Set(key, value, duration);

        return value;
    }

    public Task RemoveAsync(string key)
    {
        _cache.Remove(key);
        return Task.CompletedTask;
    }
}
