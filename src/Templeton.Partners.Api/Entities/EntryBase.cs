namespace Templeton.Partners.Api.Entities;

public abstract class EntryBase(string key, dynamic data)
{
    public string Key { get; private set; } = key;
    public dynamic Data { get; set; } = data;
}
