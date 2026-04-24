namespace Templeton.Partners.Api.Features.BestStories.BestStoriesProvider;

public static class BestStoriesProviderFeatureInjector
{
    public static void AddFeatureBestStoriesProvider(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBestStoriesProvider, BestStoriesProvider>();
    }
}
