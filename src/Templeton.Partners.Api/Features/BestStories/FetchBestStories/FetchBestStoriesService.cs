using Templeton.Partners.Api.Entities;
using Templeton.Partners.Api.Shared;

namespace Templeton.Partners.Api.Features.BestStories.FetchBestStories;

public sealed class FetchBestStoriesService(
    IFetchBestStoriesClient repository,
    ICacheServer<StoryPageEntry> cacheServer,
    ILogger<FetchBestStoriesService> logger
) : IFetchBestStoriesService
{
    public async Task ExecuteAsync()
    {
        logger.BeginScope("{Service} ", nameof(FetchBestStoriesService));
        logger.LogInformation("Fetching new best stories");

        var webApiResponse = await repository.GetAsync();

        if (!webApiResponse.IsSuccessStatusCode && webApiResponse.Error is null)
        {
            logger.LogError(
                "Error while trying to fetch new best stories: {@Error}",
                webApiResponse.Error
            );

            return;
        }

        var maxEntriesPerPage = 40; // TODO: add as envvar
        var pagesAmount = (int)
            Math.Ceiling((double)webApiResponse.Content.Count / maxEntriesPerPage);

        List<StoryPageEntry> pagesToInsert = [];
        for (int currentPage = 1; currentPage <= pagesAmount; currentPage++)
        {
            var stories = webApiResponse
                .Content.Skip(currentPage == 1 ? 0 : currentPage * maxEntriesPerPage)
                .Take(maxEntriesPerPage);

            pagesToInsert.Add(new StoryPageEntry(new StoryPage(currentPage, stories)));
        }

        var insertTasks = pagesToInsert.Select(cacheServer.SaveAsync);

        await Task.WhenAll(insertTasks);
    }
}
