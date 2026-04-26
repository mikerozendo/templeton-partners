using Templeton.Partners.Api.Features.BestStories.BestStoriesProvider;
using Templeton.Partners.Api.Features.BestStories.FetchBestStories;
using Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFeatureFetchBestStories();
builder.Services.AddFeatureBestStoriesProvider();
builder.Services.AddFeatureGetBestStoriesByPageNumber();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapFeatureGetBestStoriesByPageNumberEndpoint();
app.Run();
