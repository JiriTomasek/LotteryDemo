#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LotteryDemoBackend/LotteryDemoBackend/LotteryDemoBackend.csproj", "LotteryDemoBackend/LotteryDemoBackend/"]
COPY ["LotteryDemoBackend/LotteryDemo.Domain/LotteryDemo.Domain.csproj", "LotteryDemoBackend/LotteryDemo.Domain/"]
COPY ["LotteryDemoBackend/LotteryDemo.Database/LotteryDemo.Database.csproj", "LotteryDemoBackend/LotteryDemo.Database/"]
COPY ["LotteryDemoBackend/LotteryDemo.Entities/LotteryDemo.Entities.csproj", "LotteryDemoBackend/LotteryDemo.Entities/"]
COPY ["LotteryDemoBackend/Core/Core.csproj", "LotteryDemoBackend/Core/"]
RUN dotnet restore "LotteryDemoBackend/LotteryDemoBackend/LotteryDemoBackend.csproj"
COPY . .
WORKDIR "/src/LotteryDemoBackend/LotteryDemoBackend"
RUN dotnet build "LotteryDemoBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LotteryDemoBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LotteryDemoBackend.dll"]
