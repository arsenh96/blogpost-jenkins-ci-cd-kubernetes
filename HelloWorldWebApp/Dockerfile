# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# WORKDIR /src
# COPY "HelloWorldWebApp.csproj" .
# RUN dotnet restore "HelloWorldWebApp.csproj"

# COPY . .
# WORKDIR "/src/"
# RUN dotnet build "HelloWorldWebApp.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "/src/HelloWorldWebApp.csproj" -c Release -o /app/publish /p:UseAppHost=true

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "HelloWorldWebApp.dll"]

# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Debug: toon de inhoud van de huidige directory
RUN ls -al

# Ga naar de HelloWorldWebApp map en kopieer en herstel het .csproj bestand
WORKDIR "/src/HelloWorldWebApp"
COPY "HelloWorldWebApp/HelloWorldWebApp.csproj" .
RUN dotnet restore "HelloWorldWebApp.csproj"

# Terug naar de /src directory en kopieer alle andere bestanden
WORKDIR "/src"
COPY . .

# Bouw het project
WORKDIR "/src/HelloWorldWebApp"
RUN dotnet build "HelloWorldWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloWorldWebApp.csproj" -c Release -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWorldWebApp.dll"]
