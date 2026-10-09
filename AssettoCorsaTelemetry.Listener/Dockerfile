FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AssettoCorsaTelemetry.Listener/AssettoCorsaTelemetry.Listener.csproj", "AssettoCorsaTelemetry.Listener/"]
COPY ["AssettoCorsaTelemetry.Core/AssettoCorsaTelemetry.Core.csproj", "AssettoCorsaTelemetry.Core/"]
COPY ["AssettoCorsaTelemetry.Dal/AssettoCorsaTelemetry.Dal.csproj", "AssettoCorsaTelemetry.Dal/"]
RUN dotnet restore "AssettoCorsaTelemetry.Listener/AssettoCorsaTelemetry.Listener.csproj"
COPY . .
WORKDIR "/src/AssettoCorsaTelemetry.Listener"
RUN dotnet build "./AssettoCorsaTelemetry.Listener.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AssettoCorsaTelemetry.Listener.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssettoCorsaTelemetry.Listener.dll"]
