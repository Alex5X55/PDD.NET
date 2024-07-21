FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PDD.NET.Gateway/PDD.NET.Gateway.csproj", "PDD.NET.Gateway/"]
RUN dotnet restore "PDD.NET.Gateway/PDD.NET.Gateway.csproj"
COPY . .
WORKDIR "/src/PDD.NET.Gateway"
RUN dotnet build "PDD.NET.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PDD.NET.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDD.NET.Gateway.dll"]