namespace Templeton.Partners.Api.Shared;

public interface ICacheServer<TRecord>
    where TRecord : class
{
    Task<TRecord?> GetByKeyAsync(string key);
    Task SaveAsync(string key, TRecord entry);
}
