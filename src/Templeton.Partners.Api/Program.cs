using Templeton.Partners.Api.Features.BestStories.BestStoriesProvider;
using Templeton.Partners.Api.Features.BestStories.FetchBestStories;
using Templeton.Partners.Api.Features.BestStories.GetBestStoriesByPageNumber;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddFeatureFetchBestStories();
builder.Services.AddFeatureBestStoriesProvider();
builder.Services.AddFeatureGetBestStoriesByPageNumber();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapFeatureGetBestStoriesByPageNumberEndpoint();
app.Run();
