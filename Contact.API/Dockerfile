#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Contact.API/Contact.API.csproj", "Contact.API/"]
COPY ["Contact.Persistence/Contact.Persistence.csproj", "Contact.Persistence/"]
COPY ["Contact.Application/Contact.Application.csproj", "Contact.Application/"]
COPY ["Contact.Domain/Contact.Domain.csproj", "Contact.Domain/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "./Contact.API/./Contact.API.csproj"
COPY . .
WORKDIR "/src/Contact.API"
RUN dotnet build "./Contact.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Contact.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contact.API.dll"]