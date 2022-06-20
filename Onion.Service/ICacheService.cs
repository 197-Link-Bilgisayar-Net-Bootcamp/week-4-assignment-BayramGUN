namespace Onion.Service;

public interface ICacheService
{
    Task<string> SetCacheValueAsync(string key, string value);
    Task<string> GetCacheValueAsync(string key);
}