using Refit;
using Templeton.Partners.Api.Shared;

namespace Templeton.Partners.Api.Features.Stories.FetchBestStories;

public static class FetchBestStoriesFeatureInjector
{
    public static void AddFeatureFetchBestStories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFetchBestStoriesService, FetchBestStoriesService>();
        serviceCollection.AddScoped<ICacheServer<List<long>>, CacheServer<List<long>>>();
        serviceCollection.AddHostedService<FetchBestStoriesServiceBackgroundService>();

        serviceCollection
            .AddRefitClient<IFetchBestStoriesClient>()
            .ConfigureHttpClient(c =>
                c.BaseAddress = new Uri("https://hacker-news.firebaseio.com") //TODO: Add envvar
            );
    }
}
