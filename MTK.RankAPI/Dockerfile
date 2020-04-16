FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY MTK.RankAPI.csproj .
RUN dotnet restore "MTK.RankAPI.csproj"
COPY . .
RUN dotnet build "MTK.RankAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MTK.RankAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MTK.RankAPI.dll"]