using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;
using Templeton.Partners.Api.Entities;

namespace Templeton.Partners.Api.Shared;

public class CacheServer<TEntry, TData> : ICacheServer<TEntry, TData>
    where TEntry : EntryBase<TData>
{
    private readonly ConnectionMultiplexer _connection;
    private readonly IDatabase _database;
    private readonly JsonCommands _jsonCommands;
    private readonly ILogger<CacheServer<TEntry, TData>> _logger;

    public CacheServer(ILogger<CacheServer<TEntry, TData>> logger)
    {
        //TODO: ADD env var
        _connection = ConnectionMultiplexer.Connect(
            "localhost:6379"
        // x => x.Password = "mypassword"
        );
        _database = _connection.GetDatabase();
        _jsonCommands = _database.JSON();
        _logger = logger;
    }

    public async Task<TData?> GetByKeyAsync(string key)
    {
        var entry = await _jsonCommands.GetAsync<TData>(key, "$");

        if (entry is null)
            _logger.LogInformation("Missing hit for key {searchedKey}", key);
        else
            _logger.LogInformation("Hitting key {searchedKey}", key);

        return entry;
    }

    public async Task SaveAsync(TEntry entry)
    {
        var existingEntry = await GetByKeyAsync(entry.Key);

        if (existingEntry is null)
        {
            using var semaphore = new SemaphoreSlim(1, 1);
            await semaphore.WaitAsync();

            try
            {
                _logger.LogInformation("Creating key {searchedKey}", entry.Key);

                await _jsonCommands.SetAsync(entry.Key, "$", entry.Data);

                _logger.LogInformation(
                    "key {searchedKey} has been successfully created",
                    entry.Key
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "An error has occurred while trying to search against key {searchedKey}",
                    entry.Key
                );
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
