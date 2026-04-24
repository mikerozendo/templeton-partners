using Refit;

namespace Templeton.Partners.Api.Features.BestStories.FetchBestStories;

public interface IFetchBestStoriesClient
{
    [Get("/v0/beststories.json")]
    Task<ApiResponse<List<long>>> GetAsync();
}
