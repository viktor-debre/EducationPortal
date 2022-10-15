# Portal

## Name
Education portal web application

## Description
The specific site helps people find and learn some new educational articles, books and videos and get practical skills

## Usage
To start using the service you need only go to the site https://educationportalui20220929154907.azurewebsites.net/ and authorize

## Tech stack
- ASP.NET Core 6
- Entity Framework Core 6
- Razor pages
- SQL Server database
- Azure

## NuGet packages
- Newtonsoft.Json
- FluentValidation
- StyleCop
- Microsoft.Extensions.DependencyInjection

## Architecture
- Clean arhitecture DDD
  - Layers for the Business logic
    * Domain layer for models and interfaces for them
    * Application layer for business logic services
  - Layers for Data access
    * Infrastructure.FileSystem for storing data in JSON files
    * Infrastructure.DB for storing data in the database
  - Layer for UI
    * Presentation layer for the console application
    * UI layer for MVC Razor pages user interface 
