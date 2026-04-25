using Refit;
using Templeton.Partners.Api.Entities;
using Templeton.Partners.Api.Shared;

namespace Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

public static class GetBestStoriesByPageNumberInjector
{
    public static void AddFeatureGetBestStoriesByPageNumber(
        this IServiceCollection serviceCollection
    )
    {
        serviceCollection.AddScoped<
            IGetBestStoriesByPageNumberHandler,
            GetBestStoriesByPageNumberHandler
        >();

        serviceCollection.AddScoped<
            ICacheServer<HackerNewsStoryEntry, HackerNewsStory>,
            CacheServer<HackerNewsStoryEntry, HackerNewsStory>
        >();

        serviceCollection
            .AddRefitClient<IHackerNewsStoryClient>()
            .ConfigureHttpClient(c =>
                c.BaseAddress = new Uri("https://hacker-news.firebaseio.com") //TODO: Add envvar
            );
    }
}
