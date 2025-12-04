# Mess Management System

A starter project that pairs an ASP.NET Core 8 Web API secured with JWT authentication and an Angular 18 standalone front-end styled with Tailwind CSS.

## Project layout

- `backend/MessManagementSystem.Api/` – ASP.NET Core 8 Web API with JWT authentication endpoints (`/api/auth/login`, `/api/auth/register`, `/api/auth/me`).
- `frontend/` – Angular 18 standalone application with Tailwind-based landing, login, and registration pages.

## Backend

1. Restore and run the API:
   ```bash
   dotnet restore backend/MessManagementSystem.Api/MessManagementSystem.Api.csproj
   dotnet run --project backend/MessManagementSystem.Api/MessManagementSystem.Api.csproj
   ```
2. Swagger UI is available at `/swagger` in development. Update `appsettings.json` with your own JWT signing key before production use.

## Frontend

1. Install dependencies:
   ```bash
   cd frontend
   npm install
   ```
2. Start the development server:
   ```bash
   npm start
   ```
3. The Angular app expects the API at `http://localhost:5182`; adjust `AuthService.baseUrl` as needed.
