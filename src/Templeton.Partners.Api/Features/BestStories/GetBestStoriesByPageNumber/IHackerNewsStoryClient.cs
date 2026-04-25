using Refit;
using Templeton.Partners.Api.Entities;

namespace Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

public interface IHackerNewsStoryClient
{
    [Get("/v0/item/{storyId}.json")]
    Task<ApiResponse<HackerNewsStory>> GetAsync(long storyId);
}
