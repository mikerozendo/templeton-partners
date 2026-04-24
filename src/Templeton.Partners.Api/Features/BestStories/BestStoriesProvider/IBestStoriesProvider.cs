using Templeton.Partners.Api.Entities;

namespace Templeton.Partners.Api.Features.BestStories.BestStoriesProvider;

public interface IBestStoriesProvider
{
    Task<BestStoryPage?> GetByPageAsync(int page);
}
