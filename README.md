# SchoolProject

A .NET 7 ASP.NET Core Web API for school data. The source includes API endpoints for departments and students, SQL Server persistence, localized request cultures, and centralized error handling.

## Tech Stack

- C# and .NET 7
- ASP.NET Core Web API
- Entity Framework Core 7 with SQL Server
- MediatR, FluentValidation, and AutoMapper
- Swagger/OpenAPI
- EF Core migrations

## Architecture

```text
SchoolProject.Api            HTTP controllers, middleware, API startup
SchoolProject.Core           requests, responses, validation, and MediatR handlers
SchoolProject.Services       application services
SchoolProject.Data           data-layer project
SchoolProject.infrastructure EF Core context, migrations, repositories, and DI setup
```

The project separates controllers, core request handling, services, and persistence. It includes generic and specialized repository abstractions for departments, instructors, students, and subjects.

## Key Features

- Department and student API controllers
- SQL Server persistence with `ApplicationDbContext`
- MediatR command and query handlers
- FluentValidation validators and AutoMapper registrations
- Global error-handling middleware
- Request localization for `en-US`, `de-DE`, `fr-FR`, and `ar-EG` (Arabic is the default culture)
- CORS policy and Swagger/OpenAPI in development
- EF Core migrations

## Authentication and Security

No authentication scheme or authorization policy is configured in `Program.cs`. Before exposing the API publicly, add authentication and authorization appropriate to the application, keep connection strings out of source control, and constrain the permissive CORS policy.

## API Documentation

Swagger is configured for the Development environment. Start the API in Development and use the Swagger endpoint exposed by the running application.

## Run Locally

### Prerequisites

- .NET 7 SDK
- SQL Server

### Steps

1. Set the `DefualtConnection` connection string in the API configuration. Store credentials in user secrets or environment-specific configuration.
2. Restore and build:

```bash
dotnet restore
dotnet build
```

3. Apply migrations if needed:

```bash
dotnet ef database update --project SchoolProject.infrastructure --startup-project SchoolProject.Api
```

4. Run the API:

```bash
dotnet run --project SchoolProject.Api/SchoolProject.Api.csproj
```

## Engineering Notes

This repository is a useful backend portfolio project because its source makes the layering, EF Core configuration, validation, localization, API documentation, and error handling visible. No automated test project, Dockerfile, or compose configuration is currently present.
