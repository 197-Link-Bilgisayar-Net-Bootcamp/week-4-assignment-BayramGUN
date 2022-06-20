namespace Onion.Service;

public class InMemoryCacheService : ICacheService
{
    private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

    public Task<string> GetValueCacheAsync(string key)
    {
        return Task.FromResult(_cache.Get<string>(key));
    }
    public Task<string> SetValueCacheAsync(string key, string value)
    {
        _cache.Set(key, value);
        return Task.ComplatedTask;
    }

}