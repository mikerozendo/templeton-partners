namespace Templeton.Partners.Api.Entities;

public sealed class StoryPage(int page, IEnumerable<long> stories)
{
    public int Page { get; private set; } = page;
    public IEnumerable<long> Stories { get; private set; } = stories;
}
