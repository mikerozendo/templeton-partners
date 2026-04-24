namespace Templeton.Partners.Api.Features.Stories.FetchBestStories;

public sealed class StoryPage(int page, IEnumerable<long> stories)
{
    public string Key { get; private set; } = $"{nameof(StoryPage)}-{page}";
    public int Page { get; private set; } = page;
    public IEnumerable<long> Stories { get; private set; } = stories;
}
