namespace Templeton.Partners.Api.Entities;

public sealed class BestStoryPageEntry(BestStoryPage storyPage)
    : EntryBase($"{nameof(BestStoryPageEntry)}-{storyPage.Page}", storyPage) { }
