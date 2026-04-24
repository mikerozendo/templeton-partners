using Refit;

namespace Templeton.Partners.Api.Features.Stories.GetStoriesByPageNumber;

public interface IGetNewsByPageNumberClient
{
    [Get("/v0/item/{storyId}.json")]
    Task<ApiResponse<HackerNewsStoryDto>> GetAsync(long storyId);
}
