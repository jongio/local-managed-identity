FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 53028

ENV ASPNETCORE_URLS=http://+:53028

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["local-managed-identity.csproj", "./"]
RUN dotnet restore "local-managed-identity.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "local-managed-identity.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "local-managed-identity.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "local-managed-identity.dll"]
