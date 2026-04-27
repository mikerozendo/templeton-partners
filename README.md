# templeton-partners

## Build Instructions

### Prerequisites
- .NET SDK 10.0 installed
- Optional: Docker and Docker Compose if you want containerized builds

### Run with Docker Compose:

From the root directory:

```bash
docker compose up --build
```

### Notes
- The project targets `net10.0`.
- Dependencies are restored automatically by `dotnet build`.