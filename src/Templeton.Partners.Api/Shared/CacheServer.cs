using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

namespace Templeton.Partners.Api.Shared;

public sealed class CacheServer<TRecord> : ICacheServer<TRecord>
    where TRecord : class
{
    private readonly ConnectionMultiplexer _connection;
    private readonly IDatabase _database;
    private readonly JsonCommands _jsonCommands;

    public CacheServer()
    {
        //TODO: ADD env var
        _connection = ConnectionMultiplexer.Connect(
            "localhost:6379",
            x => x.Password = "mypassword"
        );
        _database = _connection.GetDatabase();
        _jsonCommands = _database.JSON();
    }

    public async Task<TRecord?> GetByKeyAsync(string key)
    {
        return await _jsonCommands.GetAsync<TRecord>(key, "$");
    }

    public async Task SaveAsync(string key, TRecord entry)
    {
        var existingEntry = await GetByKeyAsync(key);

        if (existingEntry is null)
        {
            using var semaphore = new SemaphoreSlim(1, 1);
            await semaphore.WaitAsync();

            try
            {
                await _jsonCommands.SetAsync(key, "$", entry);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
