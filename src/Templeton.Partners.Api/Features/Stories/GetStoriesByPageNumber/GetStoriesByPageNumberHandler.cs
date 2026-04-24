using System;

namespace Templeton.Partners.Api.Features.Stories.GetStoriesByPageNumber;

public sealed class GetStoriesByPageNumberHandler : IGetStoriesByPageNumberHandler
{
    public async Task<GetStoriesByPageNumberResult?> ExecuteAsync(int? fromPage = 1)
    {
        var maxEntries = 50;

        List<Task<HackerNewsStoryDto>> dtos = new();
        for (int i = 0; i < maxEntries; i++) { }
    }
}
