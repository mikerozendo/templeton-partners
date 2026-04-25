using Refit;
using Templeton.Partners.Api.Entities;
using Templeton.Partners.Api.Shared;

namespace Templeton.Partners.Api.Features.BestStories.FetchBestStories;

public static class FetchBestStoriesFeatureInjector
{
    public static void AddFeatureFetchBestStories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFetchBestStoriesService, FetchBestStoriesService>();

        serviceCollection.AddScoped<
            ICacheServer<BestStoryPageEntry, BestStoryPage>,
            CacheServer<BestStoryPageEntry, BestStoryPage>
        >();

        serviceCollection.AddHostedService<FetchBestStoriesServiceBackgroundService>();

        serviceCollection
            .AddRefitClient<IFetchBestStoriesClient>()
            .ConfigureHttpClient(c =>
                c.BaseAddress = new Uri("https://hacker-news.firebaseio.com") //TODO: Add envvar
            );
    }
}
