namespace Templeton.Partners.Api.Shared;

public class CacheableEntry<TEntry>(string key, TEntry data)
    where TEntry : class
{
    public string Key { get; private set; } = key;
    public TEntry Data { get; private set; } = data;
}
