using Templeton.Partners.Api.Entities;

namespace Templeton.Partners.Api.Shared;

public interface ICacheServer<TEntry>
    where TEntry : EntryBase
{
    Task<TEntry?> GetByKeyAsync(string key);
    Task SaveAsync(TEntry entry);
}
