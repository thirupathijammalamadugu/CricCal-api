# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution and project files
COPY ["src/Services/Competition/Competition.API/Competition.API.csproj", "Services/Competition/Competition.API/"]

# Restore dependencies
RUN dotnet restore "Services/Competition/Competition.API/Competition.API.csproj"

# Copy the entire project
COPY . .

# Build the application
RUN dotnet build "src/Services/Competition/Competition.API/Competition.API.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "src/Services/Competition/Competition.API/Competition.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published files from publish stage
COPY --from=publish /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:5135
ENV ASPNETCORE_ENVIRONMENT=Development

# Expose port
EXPOSE 5135

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
  CMD curl -f http://localhost:5135/health || exit 1

# Run the application
ENTRYPOINT ["dotnet", "Competition.API.dll"]
