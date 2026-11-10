FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
RUN apt-get update && apt-get install -y curl \
    && rm -rf /var/lib/apt/lists/*
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AssettoCorsaTelemetry.Api/AssettoCorsaTelemetry.Api.csproj", "AssettoCorsaTelemetry.Api/"]
RUN dotnet restore "AssettoCorsaTelemetry.Api/AssettoCorsaTelemetry.Api.csproj"
COPY . .
WORKDIR "/src/AssettoCorsaTelemetry.Api"
RUN dotnet build "./AssettoCorsaTelemetry.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AssettoCorsaTelemetry.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssettoCorsaTelemetry.Api.dll"]
