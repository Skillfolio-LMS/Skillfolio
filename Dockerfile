# Use the official .NET 9.0 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files for dependency restoration
COPY Skillfolio.sln ./
COPY src/Skillfolio.Api/Skillfolio.Api.csproj ./src/Skillfolio.Api/
COPY src/Skillfolio.Application/Skillfolio.Application.csproj ./src/Skillfolio.Application/
COPY src/Skillfolio.Domain/Skillfolio.Domain.csproj ./src/Skillfolio.Domain/
COPY src/Skillfolio.Infrastructure/Skillfolio.Infrastructure.csproj ./src/Skillfolio.Infrastructure/

# Restore dependencies
RUN dotnet restore src/Skillfolio.Api/Skillfolio.Api.csproj

# Copy source code
COPY src/ ./src/

# Build and publish the application
WORKDIR /src/src/Skillfolio.Api
RUN dotnet publish Skillfolio.Api.csproj \
    --configuration Release \
    --output /app/publish \
    --no-restore \
    /p:UseAppHost=false

# Use the official .NET 9.0 runtime image for final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Install curl for health checks and clean up in single layer
RUN apt-get update && \
    apt-get install -y --no-install-recommends curl && \
    rm -rf /var/lib/apt/lists/*

# Create non-root user for security
RUN groupadd -r skillfolio && useradd -r -g skillfolio skillfolio

# Copy published application from build stage
COPY --from=build /app/publish .

# Set ownership and switch to non-root user
RUN chown -R skillfolio:skillfolio /app
USER skillfolio

# Expose port
EXPOSE 8080

# Configure environment
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Health check
HEALTHCHECK --interval=30s --timeout=10s --start-period=40s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1

# Start the application
ENTRYPOINT ["dotnet", "Skillfolio.Api.dll"]
