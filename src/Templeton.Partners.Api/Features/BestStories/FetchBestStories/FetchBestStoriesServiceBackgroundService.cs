namespace Templeton.Partners.Api.Features.BestStories.FetchBestStories;

public sealed class FetchBestStoriesServiceBackgroundService(IServiceProvider serviceProvider)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = serviceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IFetchBestStoriesService>();
        await service.ExecuteAsync();
    }
}
