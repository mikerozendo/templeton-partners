namespace Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

public interface IGetBestStoriesByPageNumberHandler
{
    Task<IResult> ExecuteAsync(int fromPage = 1);
}
