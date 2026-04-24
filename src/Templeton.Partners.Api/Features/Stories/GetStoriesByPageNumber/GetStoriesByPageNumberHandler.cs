using System;

namespace Templeton.Partners.Api.Features.Stories.GetStoriesByPageNumber;

public sealed class GetStoriesByPageNumberHandler : IGetStoriesByPageNumberHandler
{
    public async Task<GetStoriesByPageNumberResult?> ExecuteAsync(int? fromPage = 1)
    {
        throw new NotImplementedException();
    }
}
