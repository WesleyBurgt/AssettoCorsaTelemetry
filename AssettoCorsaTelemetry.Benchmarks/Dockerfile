FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AssettoCorsaTelemetry.Benchmarks/AssettoCorsaTelemetry.Benchmarks.csproj", "AssettoCorsaTelemetry.Benchmarks/"]
RUN dotnet restore "AssettoCorsaTelemetry.Benchmarks/AssettoCorsaTelemetry.Benchmarks.csproj"
COPY . .
WORKDIR "/src/AssettoCorsaTelemetry.Benchmarks"
RUN dotnet build "./AssettoCorsaTelemetry.Benchmarks.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AssettoCorsaTelemetry.Benchmarks.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssettoCorsaTelemetry.Benchmarks.dll"]
