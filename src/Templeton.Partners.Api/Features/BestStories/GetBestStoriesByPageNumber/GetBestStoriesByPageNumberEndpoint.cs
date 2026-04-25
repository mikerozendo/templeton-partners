namespace Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

public static class GetBestStoriesByPageNumberEndpoint
{
    public static void MapFeatureGetBestStoriesByPageNumberEndpoint(
        this WebApplication? webApplication
    )
    {
        webApplication.MapGet(
            "/",
            async (int page = 1) =>
            {
                var webAppScope = webApplication.Services.CreateScope();
                var requiredService =
                    webAppScope.ServiceProvider.GetRequiredService<IGetBestStoriesByPageNumberHandler>();

                return await requiredService.ExecuteAsync(page);
            }
        );
    }
}
