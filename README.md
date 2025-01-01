# Caravan

Caravan is a .NET Core web application that provides integration services for e-commerce platforms, with a current focus on Trendyol integration. It helps manage and automate e-commerce operations through a secure web interface.

## Features

- User authentication and authorization
- Trendyol API integration
- API data management
- Docker support for easy deployment
- Secure customer data handling

## Technologies

- ASP.NET Core
- Entity Framework Core
- Docker
- Microsoft SQL Server
- Bootstrap (for frontend)

## Prerequisites

- .NET 6.0 SDK or later
- Docker (optional, for containerized deployment)
- Microsoft SQL Server

## Getting Started

1. Clone the repository:
```bash
git clone https://github.com/emre-guler/caravan
cd caravan
```

2. Configure the database connection in `appsettings.json`

3. Run the migrations:
```bash
dotnet ef database update
```

4. Run the application:
```bash
dotnet run
```

Or using Docker:
```bash
docker-compose up
```

The application will be available at `http://localhost:5000`

## Docker Support

The project includes Docker support with both production and debug configurations:
- Use `docker-compose.yml` for production
- Use `docker-compose.debug.yml` for development

## Configuration

Configure your application settings in:
- `appsettings.json` for production
- `appsettings.Development.json` for development

## API Integration

To use the Trendyol integration:
1. Log in to your account
2. Navigate to the Trendyol API settings page
3. Configure your API credentials
