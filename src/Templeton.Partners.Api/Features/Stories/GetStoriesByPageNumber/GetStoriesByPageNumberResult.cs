namespace Templeton.Partners.Api.Features.Stories.GetStoriesByPageNumber;

public sealed class GetStoriesByPageNumberResult(
    int currentPage,
    IEnumerable<HackerNewsStoryDto> data
)
{
    public IEnumerable<HackerNewsStoryDto> Data { get; private set; } = data;
    public int CurrentPage { get; private set; } = currentPage;
    public int TotalPages { get; private set; }
}
