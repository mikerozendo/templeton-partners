using Templeton.Partners.Api.Entities;

namespace Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

public sealed class GetBestStoriesByPageNumberResponse(
    int currentPage,
    IEnumerable<HackerNewsStory> data
)
{
    public IEnumerable<HackerNewsStory> Data { get; private set; } = data;
    public int CurrentPage { get; private set; } = currentPage;
    public int TotalPages { get; private set; } // TODO: needs to be fullfiled
}
