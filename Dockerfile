# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY *.sln .
COPY /src/*.csproj ./src/

RUN dotnet restore

COPY src/. ./src/

WORKDIR /app/src
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build ./app/publish .

ENTRYPOINT ["dotnet", "BunkerWebServer.dll"] 