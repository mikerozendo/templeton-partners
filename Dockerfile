FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY "Templeton.Partners.sln" .
COPY ["src/Templeton.Partners.Api/", "src/Templeton.Partners.Api/"]

RUN dotnet restore "src/Templeton.Partners.Api/Templeton.Partners.Api.csproj"

RUN dotnet publish "src/Templeton.Partners.Api/Templeton.Partners.Api.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Templeton.Partners.Api.dll"]
