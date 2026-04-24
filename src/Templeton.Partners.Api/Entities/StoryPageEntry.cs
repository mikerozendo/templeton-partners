namespace Templeton.Partners.Api.Entities;

public sealed class StoryPageEntry(StoryPage storyPage)
    : EntryBase($"{nameof(StoryPageEntry)}-{storyPage.Page}", storyPage) { }
