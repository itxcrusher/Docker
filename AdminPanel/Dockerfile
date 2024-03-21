#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base image for ASP.NET application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set user and working directory
USER app
WORKDIR /app

# Expose ports for communication
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["AdminPanel/AdminPanel.csproj", "AdminPanel/"]
RUN dotnet restore "./AdminPanel/AdminPanel.csproj"
COPY . .

# Build the application
WORKDIR "/src/AdminPanel"
RUN dotnet build "./AdminPanel.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

# Publish the application
RUN dotnet publish "./AdminPanel.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app

# Copy published files into final image
COPY --from=publish /app/publish .

# Define the entry point
ENTRYPOINT ["dotnet", "AdminPanel.dll"]