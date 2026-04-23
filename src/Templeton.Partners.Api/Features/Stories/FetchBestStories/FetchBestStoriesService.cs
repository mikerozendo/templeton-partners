namespace Templeton.Partners.Api.Features.Stories.FetchBestStories;

public sealed class FetchBestStoriesService(
    IFetchBestStoriesClient repository,
    ILogger<FetchBestStoriesService> logger
) : IFetchBestStoriesService
{
    public async Task ExecuteAsync()
    {
        logger.BeginScope("{Service} ", nameof(FetchBestStoriesService));
        logger.LogInformation("Fetching new best stories");

        var webApiResponse = await repository.GetAsync();

        if (!webApiResponse.IsSuccessStatusCode)
        {
            logger.LogError(
                "Error while trying to fetch new best stories: {@Error}",
                webApiResponse.Error
            );

            return;
        }

        throw new NotImplementedException();
    }
}
