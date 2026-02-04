# AI Coding Agent Instructions for CAMS

## Project Overview
Class Attendance Management System (CAMS) is a .NET 8 backend service using **clean architecture** with 4-layer separation:
- **CAMS.domain**: Entity models, domain logic, and value objects
- **CAMS.application**: Commands, handlers, repository abstractions
- **CAMS.infrastructure**: EF Core DbContext, SQL Server, repository implementations
- **CAMS.presentation**: ASP.NET Core API controllers and dependency injection setup

## Critical Architecture Patterns

### Domain-Driven Design & Value Objects
- **All entity properties must use Value Objects** (e.g., `CourseId`, `CourseName`, `StudentId`). Never use primitive strings/ints directly on entities.
- Value Objects are **immutable records** in `CAMS.domain/ValueValidationTypes/`. Pattern: encapsulate validation logic in `private` constructor, expose static factory method `From()` or `New()`.
- Domain Exceptions inherit from `DomainException` in `CAMS.domain/Errors/`. Create specific exception classes for each validation failure (e.g., `InvalidCourseName`, `InvalidStudentId`).
- **Example**: [CourseCode.cs](CAMS.domain/ValueValidationTypes/CourseCode.cs) derives code from name; [Course.cs](CAMS.domain/Courses/Course.cs) enforces private constructor with static `Create()` factory.

### CQRS with Command Handlers
- Commands are **immutable records** in `CAMS.application/{Feature}/Create/`. Pattern: `CreateCourseCommand(string CourseName, int CourseDuration)`.
- Handlers implement the business logic, receive dependencies (repositories) via constructor injection, and return `Result<T>` or `Result`.
- **Placement**: Handlers live in same folder as commands (e.g., `CAMS.application/Courses/Create/CreateCourseHandler.cs`).

### Result Pattern for Error Handling
- Use `Result` and `Result<T>` classes from `CAMS.application/Common/Results/` to return operation outcomes.
- **Never throw exceptions from handlers**; return `Result.Failure(errorMessage)` or `Result.Success()`.
- `Result` validates: success must have empty error message; failure must have error message.

### Repository Abstraction
- Define interfaces in `CAMS.application/Abstractions/Persistence/` (e.g., `ICourseRepository`).
- Implement in `CAMS.infrastructure/Persistence/Repositories/`. Use EF Core with repository pattern.
- Repositories are scoped dependencies, registered via `DependencyInjection.cs` in infrastructure layer.

## Development Workflows

### Building & Running
```bash
dotnet build
dotnet run --project CAMS.presentation/CAMS.presentation.csproj
```
API runs on `https://localhost:5001` with Swagger at `/swagger/ui`.

### Code Formatting (Pre-Commit Hook)
This repo uses **Husky.Net** to auto-format staged files with `dotnet format` before every commit.
- Formatting runs automatically—no manual intervention needed.
- If setup required: `dotnet husky attach CAMS.presentation/CAMS.presentation.csproj`.

### Database
- SQL Server via Docker: `docker-compose up` (see [compose.yaml](compose.yaml)).
- EF Core migrations: Add to [AppDbContext.cs](CAMS.infrastructure/Persistence/AppDbContext.cs) and use `dotnet ef migrations add`.
- Entity configurations in [Configurations/](CAMS.infrastructure/Persistence/Configurations/) (e.g., `CourseConfiguration.cs`).

## Project-Specific Conventions

### Naming & Folder Structure
- Feature folders organize commands, handlers, and queries by domain concept: `CAMS.application/{Feature}/{Operation}/`.
- Example: `Create` folder for `CreateCourseCommand` + `CreateCourseHandler`.
- **Note**: Typo in codebase: `Resullts/` folder should be `Results/`. Preserve existing typo for now but fix in future refactors.

### Dependency Injection Flow
1. `CAMS.presentation/Program.cs` calls `AddInfrastructure()` from infrastructure DI container.
2. `CAMS.infrastructure/DependencyInjection.cs` registers DbContext and repositories.
3. Services autowired into handlers and controllers via constructor injection.

### Controllers & API Design
- Controllers in `CAMS.presentation/Controllers/` are thin orchestration layers.
- Inject handlers/services, call them, return HTTP responses with `Result` outcomes.
- Example pattern: `CreateCourseCommand` → handler → repository → `Result<Course>` → HTTP response.

## Integration Points & External Dependencies

### Entity Framework Core
- Used for persistence with SQL Server.
- Entities mapped via configurations (e.g., `CourseConfiguration` in `Persistence/Configurations/`).
- Repositories abstract EF queries—**never expose IQueryable or DbContext outside infrastructure layer**.

### Docker & Deployment
- [Dockerfile](CAMS.presentation/Dockerfile) for containerized API.
- [compose.yaml](compose.yaml) orchestrates API + SQL Server for local development.

## Common Tasks

### Adding a New Feature
1. Create Value Objects in `CAMS.domain/ValueValidationTypes/{FeatureName}.cs`.
2. Create domain entity/aggregate in `CAMS.domain/{Feature}/{Entity}.cs` with private constructor + static factory.
3. Create command in `CAMS.application/{Feature}/Create/Create{Entity}Command.cs`.
4. Create handler in `Create{Entity}Handler.cs` (same folder).
5. Define repository interface in `CAMS.application/Abstractions/Persistence/I{Entity}Repository.cs`.
6. Implement repository in `CAMS.infrastructure/Persistence/Repositories/{Entity}Repository.cs`.
7. Register repository in `CAMS.infrastructure/DependencyInjection.cs`.
8. Create controller endpoint in `CAMS.presentation/Controllers/{Feature}Controller.cs`.

### Validation & Error Handling
- Validation logic belongs in **value object factories** or **domain entities**, not handlers.
- Throw domain-specific exceptions (inherit from `DomainException`).
- Handlers catch exceptions and convert to `Result.Failure(message)`.
