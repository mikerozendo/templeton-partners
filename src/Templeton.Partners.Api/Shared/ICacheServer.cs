using Templeton.Partners.Api.Entities;

namespace Templeton.Partners.Api.Shared;

public interface ICacheServer<TEntry, TData>
    where TEntry : EntryBase<TData>
{
    Task<TData?> GetByKeyAsync(string key);
    Task SaveAsync(TEntry entry);
}
