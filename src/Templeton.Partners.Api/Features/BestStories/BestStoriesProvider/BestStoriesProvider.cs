using Templeton.Partners.Api.Entities;
using Templeton.Partners.Api.Shared;

namespace Templeton.Partners.Api.Features.BestStories.BestStoriesProvider;

public sealed class BestStoriesProvider(ICacheServer<BestStoryPageEntry> cacheServer)
    : IBestStoriesProvider
{
    public async Task<BestStoryPage?> GetByPageAsync(int page)
    {
        var cacheEntry = await cacheServer.GetByKeyAsync(new BestStoryPageEntry(page).Key);
        return cacheEntry is null
            ? null
            : new BestStoryPage(page, (IEnumerable<long>)cacheEntry.Data);
    }
}
