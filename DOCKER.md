# CricCal API - Docker Setup

## Prerequisites
- Docker Desktop installed and running
- Docker Compose installed (usually comes with Docker Desktop)

## Quick Start

### Build and Run All Services
```bash
cd /path/to/CricCal-api
docker-compose up -d
```

### Build Services Only
```bash
docker-compose build
```

### View Logs
```bash
# All services
docker-compose logs -f

# Specific service
docker-compose logs -f account-api
docker-compose logs -f sqlserver
```

### Stop Services
```bash
docker-compose down
```

### Remove Everything (including volumes)
```bash
docker-compose down -v
```

## Service URLs

- **Account API**: http://localhost:5134
- **Account API Swagger**: http://localhost:5134/swagger
- **Competition API**: http://localhost:5135 (optional, use `docker-compose up -d -p optional`)
- **SQL Server**: localhost:1433

## Environment Variables

### SQL Server
- **SA Password**: `YourPassword@123`
- **Database**: `AccountDb`
- **Port**: 1433

### Connection String
```
Server=sqlserver,1433;Database=AccountDb;User Id=sa;Password=YourPassword@123;TrustServerCertificate=true;
```

## Running Specific Services

### Only Account API and SQL Server
```bash
docker-compose up -d account-api sqlserver
```

### Only Competition API
```bash
docker-compose --profile optional up -d competition-api
```

## Development

### Rebuild a Single Service
```bash
docker-compose build --no-cache account-api
docker-compose up -d account-api
```

### Execute Command in Container
```bash
docker-compose exec account-api dotnet --version
```

## Troubleshooting

### Port Already in Use
Change the port mapping in `docker-compose.yml`:
```yaml
ports:
  - "5134:5134"  # Change first number to different port
```

### Database Connection Issues
1. Ensure SQL Server container is healthy: `docker-compose ps`
2. Check logs: `docker-compose logs sqlserver`
3. Verify connection string in `appsettings.json`

### Application Crashes
Check logs:
```bash
docker-compose logs account-api
```

## Production Considerations

For production deployment:
1. Change default SQL Server password in `docker-compose.yml`
2. Set `ASPNETCORE_ENVIRONMENT` to `Production`
3. Use secrets management for sensitive data
4. Configure proper volume persistence
5. Add reverse proxy (nginx/Traefik)
6. Use environment-specific compose files
