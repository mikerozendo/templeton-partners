using Refit;

namespace Templeton.Partners.Api.Features.Stories.FetchBestStories;

public static class FetchBestStoriesFeatureInjector
{
    public static void AddFeatureFetchBestStories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFetchBestStoriesService, FetchBestStoriesService>();

        serviceCollection.AddHostedService<FetchBestStoriesServiceBackgroundService>();

        serviceCollection
            .AddRefitClient<IFetchBestStoriesClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(""));
    }
}
