#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Presentation/B3.API/B3.API.csproj", "src/Presentation/B3.API/"]
RUN dotnet restore "src/Presentation/B3.API/B3.API.csproj"
COPY . .
WORKDIR "/src/src/Presentation/B3.API"
RUN dotnet build "B3.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "B3.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "B3.API.dll"]