namespace Templeton.Partners.Api.Features.Stories.FetchBestStories;

public sealed class FetchBestStoriesServiceBackgroundService(IServiceProvider serviceProvider)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IFetchBestStoriesService>();
            await service.ExecuteAsync();

            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }
    }
}
