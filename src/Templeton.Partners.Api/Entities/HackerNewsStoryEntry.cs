namespace Templeton.Partners.Api.Entities;

public sealed class HackerNewsStoryEntry : EntryBase
{
    public HackerNewsStoryEntry(HackerNewsStory hackerNewsStory, long storyId)
        : base(hackerNewsStory, nameof(HackerNewsStoryEntry), storyId.ToString()) { }

    public HackerNewsStoryEntry(long storyId)
        : base(nameof(HackerNewsStoryEntry), storyId.ToString()) { }
}
