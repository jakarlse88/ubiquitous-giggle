#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MTK.RankAPI/MTK.RankAPI.csproj", "MTK.RankAPI/"]
COPY ["EventBus/MTK.EventBusRabbitMq/MTK.EventBusRabbitMq.csproj", "EventBus/MTK.EventBusRabbitMq/"]
COPY ["EventBus/MTK.EventBus/MTK.EventBus.csproj", "EventBus/MTK.EventBus/"]
RUN dotnet restore "MTK.RankAPI/MTK.RankAPI.csproj"
COPY . .
WORKDIR "/src/MTK.RankAPI"
RUN dotnet build "MTK.RankAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MTK.RankAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MTK.RankAPI.dll"]