namespace Templeton.Partners.Api.Entities;

public interface IEntry<TData>
{
    string Key { get; }
    TData Data { get; }
}
