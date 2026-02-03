# Task Management API

A RESTful Task Management API built with ASP.NET Core and Entity Framework Core.  
This project was created as part of my .NET learning journey, with a focus on clean architecture, relational data modeling, and real-world API design.

---

## Overview

The Task Management API allows managing projects and their associated tasks.  
It demonstrates how to build a backend API from scratch using modern .NET practices, including:

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Code-first migrations
- Proper entity relationships
- RESTful endpoints

---

## Tech Stack

- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core
- SQL Server / SQL Server Express
- Swagger (OpenAPI)
- C#

---

## Domain Model

**Project**
- Id
- Name
- Description
- Collection of TaskItems

**TaskItem**
- Id
- Title
- Description
- Status
- ProjectId (FK)

Relationships:
- One Project → Many TaskItems
- TaskItems belong to a single Project

Entity relationships are configured using Fluent API.

---

## Features

- Create, read, update, and delete projects
- Create, read, update, and delete tasks
- Tasks are always associated with a project
- Proper use of HTTP status codes
- Database migrations with EF Core
- Swagger UI for API testing

---

## Project Structure

TaskManagementAPI/
│
├── Controllers/ # API controllers
├── Data/ # DbContext and database configuration
├── Models/Entities/ # Domain entities
├── Migrations/ # EF Core migrations
├── Program.cs # Application startup
├── appsettings.json # Configuration


---

## How to Run Locally

1. Clone the repository
2. Open the solution in Visual Studio
3. Update the connection string in `appsettings.json` if needed
4. Run database migrations:
Update-Database

5. Run the application
6. Open Swagger at:
https://localhost:{port}/swagger


---

## What I Practiced and Learned

- Designing RESTful APIs in ASP.NET Core
- Using Entity Framework Core with SQL Server
- Modeling one-to-many relationships correctly
- Fluent API vs Data Annotations
- Handling common EF Core and routing issues
- Debugging migrations and connection problems
- Structuring a backend project cleanly

---

## Notes

This project is part of a larger `.NET Learning` repository.  
The goal is learning, experimentation, and building strong backend fundamentals rather than production deployment.

---

## Next Improvements

- Add DTOs and AutoMapper
- Add validation (FluentValidation)
- Add authentication and authorization (JWT)
- Add pagination and filtering
- Add unit tests
