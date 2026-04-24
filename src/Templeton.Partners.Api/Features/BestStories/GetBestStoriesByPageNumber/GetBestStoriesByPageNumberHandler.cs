namespace Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

public sealed class GetBestStoriesByPageNumberHandler : IGetBestStoriesByPageNumberHandler
{
    public async Task<GetBestStoriesByPageNumberResponse?> ExecuteAsync(int? fromPage = 1)
    {
        var maxEntries = 50;

        List<Task<HackerNewsStoryDto>> dtos = new();
        for (int i = 0; i < maxEntries; i++) { }
        throw new NotImplementedException();
    }
}
