using Refit;

namespace Templeton.Partners.Api.Features.Stories.FetchBestStories;

public interface IFetchBestStoriesClient
{
    [Get("/v0/beststories.json")]
    Task<ApiResponse<List<long>>> GetAsync();
}
