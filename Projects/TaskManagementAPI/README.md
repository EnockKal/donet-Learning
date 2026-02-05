# Task Management API

A RESTful Task Management API built with ASP.NET Core and Entity Framework Core.

This project is part of my .NET learning journey and focuses on building a real-world backend API with clean architecture, proper relational data modeling, and RESTful design practices.

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
- Clean separation of concerns

---

## Tech Stack

- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core
- SQL Server / SQL Server Express
- Swagger (OpenAPI)
- C#

---

## Domain Model

### Project
- Id
- Name
- Description
- CreatedAt
- Collection of TaskItems

### TaskItem
- Id
- Title
- Description
- Status
- Priority
- DueDate
- ProjectId (FK)
- UserId (nullable FK)

### User
- Id
- Name
- Email
- Collection of TaskItems

### Relationships
- One Project → Many TaskItems
- TaskItem belongs to exactly one Project
- TaskItem can optionally be assigned to one User
- One User → Many TaskItems

Entity relationships are configured using Fluent API.

---

## Features

### Projects
- Create project
- Get all projects
- Get project by id
- Update project
- Delete project

### Tasks
- Create task under a project
- Get all tasks
- Get task by id
- Get all tasks for a specific project
- Update task
- Delete task
- Tasks are always associated with a project

### General
- Proper use of HTTP status codes
- DTO-based request and response models
- Database migrations with EF Core
- Swagger UI for API testing

---

## Current Progress

- Projects CRUD ✅
- Tasks CRUD ✅
- Get tasks by project ✅
- Task assignment 🔄 In progress
- User management ⏳ Planned

---

## Project Structure

<img width="491" height="587" alt="image" src="https://github.com/user-attachments/assets/493face8-5291-4bfc-8ff1-c74e356a3cef" />

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
- Proper use of DTOs and HTTP responses

---

## Notes

This project is part of a larger **.NET learning repository**.
The goal is to strengthen backend fundamentals and understand how real-world APIs are designed, rather than focusing on production deployment.

---

## Next Improvements

- Complete task assignment feature
- Add full user management
- Add validation (FluentValidation)
- Add authentication and authorization (JWT)
- Add pagination and filtering
- Add unit tests
- Introduce AutoMapper
