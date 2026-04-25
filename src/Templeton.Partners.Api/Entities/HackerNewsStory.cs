namespace Templeton.Partners.Api.Entities;

public sealed class HackerNewsStory
{
    public string By { get; set; }
    public int Descendants { get; set; }
    public long Id { get; set; }
    public List<long> Kids { get; set; } = new();
    public int Score { get; set; }
    public long Time { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
}
