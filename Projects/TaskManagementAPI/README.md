# Task Management API

A production‑style RESTful backend API built with ASP.NET Core and Entity Framework Core. This project was developed as a hands‑on learning and portfolio project to demonstrate clean API design, correct relational data modeling, and real‑world backend patterns.

This API manages Projects, Tasks, and Users, with full CRUD operations, task assignment logic, and safe deletion handling using proper foreign‑key constraints.

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

### Projects
- Create, update, delete projects
- Get all projects or a project by id
- One‑to‑many relationship: Project → TaskItems
- Restrictive delete behavior to protect related tasks

### Tasks (TaskItem)
- Create tasks under a project
- Get all tasks or tasks by project
- Get task by id
- Update task details (title, description, status, priority, due date)
- Delete tasks
- Task status and priority implemented using enums

### Users
- Create users
- Get all users or user by id
- Update user information
- Delete users with safe foreign‑key handling

### Task Assignment
- Assign a task to a user
- Reassign a task to another user
- Unassign a task from a user
- Retrieve tasks assigned to a specific user

### Data Modeling Relationships
- One Project → Many TaskItems: One‑to‑Many (required)
- One User → Many TaskItems One‑to‑Many (optional)
- Tasks can exist without an assigned user
- Task belongs to exactly one Project
- Task can optionally be assigned to one User

Entity relationships are configured using Fluent API.

### Delete User Logic (Foreign‑Key Safe)
When deleting a user:

1. The API checks if the user exists
2. It checks whether the user has assigned tasks
3. If tasks exist, they are automatically unassigned (`UserId = null`)
4. The user is then deleted

This approach preserves task data while respecting database constraints.

---

### General
- Proper use of HTTP status codes
- DTO-based request and response models
- Database migrations with EF Core
- Swagger UI for API testing

---

## Current Progress

✅ **Completed**

This project meets the minimum scope for a resume-ready backend API and demonstrates strong fundamentals in ASP.NET Core and Entity Framework Core.

---

## What I Practiced and Learned

- Designing RESTful APIs in ASP.NET Core
- Using Entity Framework Core with SQL Server
- Modeling one-to-many relationships correctly
- Fluent API vs Data Annotations
- Handling foreign key constraints safely
- Implementing task assignment logic
- Debugging EF Core migrations and connection issues
- Structuring a backend project cleanly
- Proper use of DTOs and HTTP responses

---

## Possible Next Improvements

- Add validation (FluentValidation)
- JWT authentication and authorization
- Pagination and filtering
- Unit and integration tests (xUnit)
- Frontend integration using React + TypeScript
- Introduce AutoMapper

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

## Notes

This project is part of a larger **.NET learning repository**.
The goal is to strengthen backend fundamentals and understand how real-world APIs are designed, rather than focusing on production deployment.

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

