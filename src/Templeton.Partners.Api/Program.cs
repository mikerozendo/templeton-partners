using Templeton.Partners.Api.Features.BestStories.BestStoriesProvider;
using Templeton.Partners.Api.Features.BestStories.FetchBestStories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddFeatureFetchBestStories();
builder.Services.AddFeatureBestStoriesProvider();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
