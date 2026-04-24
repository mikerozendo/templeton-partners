namespace Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

public interface IGetBestStoriesByPageNumberHandler
{
    Task<GetBestStoriesByPageNumberResponse?> ExecuteAsync(int? fromPage = 1);
}
