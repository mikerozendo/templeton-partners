using Templeton.Partners.Api.Entities;
using Templeton.Partners.Api.Features.BestStories.BestStoriesProvider;
using Templeton.Partners.Api.Shared;

namespace Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

public sealed class GetBestStoriesByPageNumberHandler(
    IBestStoriesProvider bestStoriesProvider,
    ICacheServer<HackerNewsStoryEntry> cacheServer
) : IGetBestStoriesByPageNumberHandler
{
    public async Task<IResult> ExecuteAsync(int fromPage = 1)
    {
        //GetBestStoriesByPageNumberResponse
        var maxEntries = 50; // TODO: ENV VAR

        var storiesForSearchedPage = await bestStoriesProvider.GetByPageAsync(fromPage);
        if (storiesForSearchedPage is null)
            return Results.NotFound();

        var searchScam = new List<Tuple<long, bool>>();
        var cacheTasks = storiesForSearchedPage.Stories.Select(x =>
        {
            var task = cacheServer.GetByKeyAsync(new HackerNewsStoryEntry(x).Key);
            task.ContinueWith(y =>
            {
                searchScam.Add(
                    Tuple.Create(x, y.Status == TaskStatus.RanToCompletion && y.Result != null)
                );
            });
            return task;
        });
        await Task.WhenAll(cacheTasks);

        // List<Task<HackerNewsStoryDto>> dtos = new();
        throw new NotImplementedException();
    }
}
