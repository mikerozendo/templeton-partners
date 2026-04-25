namespace Templeton.Partners.Api.Entities;

public abstract class EntryBase<TData> : IEntry<TData>
{
    public TData? Data { get; private set; }
    public string Key { get; private set; }

    protected EntryBase(TData data, params string[] keyParameters)
    {
        Key = string.Join("-", keyParameters);
        Data = data;
    }

    protected EntryBase(params string[] keyParameters)
    {
        Key = string.Join("-", keyParameters);
    }
}
