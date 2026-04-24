namespace Templeton.Partners.Api.Features.Stories.GetStoriesByPageNumber;

public interface IGetStoriesByPageNumberHandler
{
    Task<GetStoriesByPageNumberResult?> ExecuteAsync(int? fromPage = 1);
}
