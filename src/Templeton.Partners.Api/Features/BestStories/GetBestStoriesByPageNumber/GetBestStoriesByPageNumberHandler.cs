using System.Collections.Concurrent;
using Templeton.Partners.Api.Entities;
using Templeton.Partners.Api.Features.BestStories.BestStoriesProvider;
using Templeton.Partners.Api.Shared;

namespace Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

public sealed class GetBestStoriesByPageNumberHandler(
    IBestStoriesProvider bestStoriesProvider,
    ICacheServer<HackerNewsStoryEntry, HackerNewsStory> cacheProvider,
    IHackerNewsStoryClient hackerNewsStoryClient,
    ILogger<GetBestStoriesByPageNumberHandler> logger
) : IGetBestStoriesByPageNumberHandler
{
    public async Task<IResult> ExecuteAsync(int fromPage = 1)
    {
        try
        {
            var fromCurrentPage = await bestStoriesProvider.GetByPageAsync(fromPage);
            if (fromCurrentPage is null)
                return Results.NotFound();

            var searchScam = new ConcurrentDictionary<long, HackerNewsStory?>();
            var fetchFromCacheTasks = fromCurrentPage
                .Stories.Select(x =>
                {
                    var task = cacheProvider.GetByKeyAsync(new HackerNewsStoryEntry(x).Key);
                    task.ContinueWith(y =>
                    {
                        searchScam.TryAdd(x, y.Result);
                    });
                    return task;
                })
                .ToList();

            await Task.WhenAll(fetchFromCacheTasks);

            var fetchMissingFromHttpClient = searchScam
                .Select(x =>
                {
                    if (x.Value is not null)
                        return Task.CompletedTask;

                    var task = hackerNewsStoryClient.GetByAsync(x.Key);
                    task.ContinueWith(async y =>
                    {
                        if (task.Result.IsSuccessStatusCode && task.Result.Error is null)
                        {
                            searchScam[x.Key] = task.Result.Content;
                            await cacheProvider.SaveAsync(
                                new HackerNewsStoryEntry(task.Result.Content, x.Key)
                            );
                        }
                    });
                    return task;
                })
                .ToList();

            await Task.WhenAll(fetchMissingFromHttpClient);

            //TODO:map response
            throw new NotImplementedException();
        }
        catch (Exception ex) //TODO:add global exception handler
        {
            logger.LogError(
                ex,
                "An error has occurred while trying executing {Handler}",
                nameof(GetBestStoriesByPageNumberHandler)
            );

            return Results.InternalServerError();
        }
    }
}
