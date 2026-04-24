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
    private readonly ILogger<CacheServer<TRecord>> _logger;

    public CacheServer(ILogger<CacheServer<TRecord>> logger)
    {
        //TODO: ADD env var
        _connection = ConnectionMultiplexer.Connect(
            "localhost:6379",
            x => x.Password = "mypassword"
        );
        _database = _connection.GetDatabase();
        _jsonCommands = _database.JSON();
        _logger = logger;
    }

    public async Task<TRecord?> GetByKeyAsync(string key)
    {
        var result = await _jsonCommands.GetAsync<TRecord>(key, "$");

        if (result is null)
            _logger.LogInformation("Missing hit for key {searchedKey}", key);
        else
            _logger.LogInformation("Hitting key {searchedKey}", key);

        return result;
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
                _logger.LogInformation("Creating key {searchedKey}", key);

                await _jsonCommands.SetAsync(key, "$", entry);

                _logger.LogInformation("key {searchedKey} has been successfully created", key);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "An error has occurred while trying to search against key {searchedKey}",
                    key
                );
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
