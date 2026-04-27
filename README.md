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