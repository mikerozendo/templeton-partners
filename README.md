# templeton-partners

## Build Instructions

### Prerequisites
- .NET SDK 10.0 installed
- Optional: Docker and Docker Compose for containerized execution

### Run with Docker Compose
From the root directory:

```bash
docker compose up --build
```

The API is exposed at `http://localhost:8080` when using Docker Compose.

## API Endpoint

### GET /

Returns a page of Hacker News best stories that are cached and served by the API.

Query parameters:
- `page` (optional, integer): page number to fetch. Default is `1`.

Examples:

```bash
curl "http://localhost:8080/?page=1"
```

```bash
curl "http://localhost:8080/"
```

Response shape:

```json
{
  "data": [
    {
      "id": 123456,
      "title": "Example story title",
      "url": "https://example.com/story",
      "score": 100,
      "by": "author",
      "time": 1710000000,
      "descendants": 123
    }
  ],
  "currentPage": 1
}
```

Notes:
- If `page` is omitted, the API returns the first page of results.

### Notes
- The project targets `net10.0`.
- Dependencies are restored automatically by `dotnet build`.


## Build Instructions

### Prerequisites
- .NET SDK 10.0 installed
- Optional: Docker and Docker Compose if you want containerized builds

### Run with Docker Compose:

From the root directory:

```bash
docker compose up --build
```

## Technologies Used

This application is built using modern technologies to ensure performance, scalability, and maintainability:

- **.NET 10**: The core framework for building the API. .NET 10 provides the latest features, performance improvements, and cross-platform support for developing robust web applications.
- **Redis**: Used as the caching layer to store and retrieve Hacker News stories efficiently. Redis offers high-speed data access, making it ideal for caching frequently requested data and reducing load on external APIs.

Other technologies include Docker for containerization and Docker Compose for orchestrating multi-container applications.

## Architecture

This application follows the **Vertical Slice Architecture** pattern, where features are organized vertically rather than horizontally. Each feature encapsulates all the necessary components (handlers, services, entities, etc.) within its own slice, promoting better separation of concerns and maintainability.

### Key Features and Services

- **BestStories Feature**:
  - `BestStoriesProvider`: Responsible for providing best stories data.
  - `FetchBestStories`: Handles fetching best stories from external sources (Hacker News API).
  - `GetBestStoriesByPageNumber`: Endpoint for retrieving paginated best stories.

- **Shared Services**:
  - `CacheServer`: Implements caching mechanism to store and retrieve data efficiently.

- **Entities**:
  - `BestStoryPage`, `BestStoryPageEntry`, `HackerNewsStory`, etc.: Data models representing the domain objects.

## Technical Debts and Points for Improvement

While the application is functional, there are several areas identified as technical debts that could be addressed for better performance, maintainability, and scalability:

- **Testing**: Lack of comprehensive unit and integration tests. Adding tests for services, handlers, and endpoints would improve code reliability.
- **Error Handling**: Limited error handling and logging. Implementing global exception handling and structured logging would enhance debugging and monitoring.
- **Configuration Management**: Some hardcoded values (e.g., API endpoints) should be moved to configuration files for easier environment management.
- **Authentication and Security**: No authentication mechanism is implemented.
- **Performance Monitoring**: No metrics or monitoring tools integrated. Adding Application Insights or similar would help track performance.
- **Documentation**: API documentation could be improved with tools like Swagger/OpenAPI for better developer experience.