namespace Templeton.Partners.Api.Entities;

public sealed class BestStoryPageEntry : EntryBase<BestStoryPage>
{
    public BestStoryPageEntry(BestStoryPage storyPage)
        : base(storyPage, nameof(BestStoryPageEntry), storyPage.Page.ToString()) { }

    public BestStoryPageEntry(int page)
        : base(nameof(BestStoryPageEntry), page.ToString()) { }
}
