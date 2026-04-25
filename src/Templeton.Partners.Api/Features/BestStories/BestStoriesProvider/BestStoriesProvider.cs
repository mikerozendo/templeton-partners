using Templeton.Partners.Api.Entities;
using Templeton.Partners.Api.Shared;

namespace Templeton.Partners.Api.Features.BestStories.BestStoriesProvider;

public sealed class BestStoriesProvider(ICacheServer<BestStoryPageEntry, BestStoryPage> cacheServer)
    : IBestStoriesProvider
{
    public async Task<BestStoryPage?> GetByPageAsync(int page) =>
        await cacheServer.GetByKeyAsync(new BestStoryPageEntry(page).Key);
}
