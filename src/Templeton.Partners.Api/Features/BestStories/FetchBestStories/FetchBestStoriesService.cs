using System.Net.WebSockets;
using Templeton.Partners.Api.Entities;
using Templeton.Partners.Api.Shared;

namespace Templeton.Partners.Api.Features.BestStories.FetchBestStories;

public sealed class FetchBestStoriesService(
    IFetchBestStoriesClient repository,
    ICacheServer<BestStoryPageEntry, BestStoryPage> cacheServer,
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

        var maxEntriesPerPage = 50; // TODO: add as envvar
        var pagesAmount = (int)
            Math.Ceiling((double)webApiResponse.Content.Count / maxEntriesPerPage);

        List<BestStoryPageEntry> pagesToInsert = [];
        for (int currentPage = 1; currentPage <= pagesAmount; currentPage++)
        {
            var toSkip = currentPage == 1 ? 0 : (currentPage - 1) * maxEntriesPerPage;
            var stories = webApiResponse.Content.Skip(toSkip).Take(maxEntriesPerPage);

            pagesToInsert.Add(new BestStoryPageEntry(new BestStoryPage(currentPage, stories)));
        }

        var insertTasks = pagesToInsert.Select(cacheServer.SaveAsync);

        await Task.WhenAll(insertTasks);
    }
}
