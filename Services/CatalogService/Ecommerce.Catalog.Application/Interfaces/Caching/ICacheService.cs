namespace Ecommerce.Catalog.Application.Interfaces.Caching;

public interface ICacheService
{
    Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> fetch, TimeSpan duration);
    Task RemoveAsync(string key);
}