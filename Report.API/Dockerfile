#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Report.API/Report.API.csproj", "Report.API/"]
COPY ["Report.Application/Report.Application.csproj", "Report.Application/"]
COPY ["Report.Domain/Report.Domain.csproj", "Report.Domain/"]
COPY ["Report.Persistence/Report.Persistence.csproj", "Report.Persistence/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "./Report.API/./Report.API.csproj"
COPY . .
WORKDIR "/src/Report.API"
RUN dotnet build "./Report.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Report.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Report.API.dll"]