FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src
COPY ["KweetService.Api/KweetService.Api.csproj", "KweetService.Api/"]
COPY ["KweetService.Data/KweetService.Data.csproj", "KweetService.Data/"]
COPY ["KweetService.Domain/KweetService.Domain.csproj", "KweetService.Domain/"]
COPY ["KweetService.Domain.Text/KweetService.Domain.Text.csproj", "KweetService.Domain.Text/"]
COPY ["KweetService.Service/KweetService.Service.csproj", "KweetService.Service/"]

RUN dotnet restore "KweetService.Api/KweetService.Api.csproj"
COPY . .
WORKDIR /src/KweetService.Api

RUN dotnet build "KweetService.Api.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "KweetService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KweetService.Api.dll"]