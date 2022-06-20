namespace Onion.Service;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<string> GetValueCacheAsync(string key)
    {
        var db = _connectionMultiplexer.GetDataBase();
        return await db.StringGetAsync(key);
    }
    public async Task<string> SetValueCacheAsync(string key, string value)
    {
        var db = _connectionMultiplexer.GetDataBase();

        await db.StringSetAsync(key, value);
    }
}
