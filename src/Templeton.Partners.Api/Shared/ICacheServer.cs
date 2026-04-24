namespace Templeton.Partners.Api.Shared;

public interface ICacheServer<TRecord>
    where TRecord : CacheableEntry<TRecord>
{
    Task SaveAsync(TRecord entry);
    Task<TRecord?> GetByKeyAsync(string key);
}
