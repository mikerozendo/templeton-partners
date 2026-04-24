namespace Templeton.Partners.Api.Entities;

public abstract class EntryBase
{
    public dynamic Data { get; private set; }
    public string Key { get; private set; }

    public EntryBase(dynamic data, params string[] keyPameters)
    {
        SetKey(keyPameters);
        Data = data;
    }

    public EntryBase(params string[] keyParameters)
    {
        SetKey(keyParameters);
    }

    private void SetKey(params string[] keyParameters)
    {
        Key = string.Join("-", keyParameters);
    }
}
