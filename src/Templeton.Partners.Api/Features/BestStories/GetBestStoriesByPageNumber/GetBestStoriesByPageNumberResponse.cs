namespace Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

public sealed class GetBestStoriesByPageNumberResponse(
    int currentPage,
    IEnumerable<HackerNewsStoryDto> data
)
{
    public IEnumerable<HackerNewsStoryDto> Data { get; private set; } = data;
    public int CurrentPage { get; private set; } = currentPage;
    public int TotalPages { get; private set; }
}
