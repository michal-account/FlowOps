# FlowOps Project Instructions

## Project Context
FlowOps is an Incident & SLA Management System built with .NET 10 and Angular 22.
The solution follows strict Clean Architecture principles (Senior/Mid interview portfolio standard).

## Tech Stack & Pinned Versions
- Backend: .NET 10, C# modern features (records, file-scoped namespaces, pattern matching).
- Data Layer: PostgreSQL via Docker, Entity Framework Core `10.0.4`, Npgsql `10.0.3` (DO NOT bump EF Core above 10.0.4 to prevent version conflicts).
- Caching & Realtime: Redis, SignalR with Redis Backplane.
- Patterns: Clean Architecture, CQRS (MediatR), FluentValidation.
- Frontend: Angular 22 (Standalone components, Signals, Tailwind CSS).

## Architecture & Dependency Rules
1. FlowOps.Domain: Zero external dependencies. Entities, Enums, Domain Exceptions.
2. FlowOps.Application: Depends ONLY on Domain. Contains CQRS Commands/Queries, Handlers, Interfaces. Never reference EF Core or Infrastructure directly (use `IFlowOpsDbContext`).
3. FlowOps.Infrastructure: Implements Application interfaces, contains DbContext, migrations, external services.
4. FlowOps.Api: Entry point, registers DI, Minimal APIs / Controllers, SignalR Hubs.

## Coding Standards
- Always use file-scoped namespaces (`namespace FlowOps...;`).
- Commands and Queries must be defined as immutable `record` types.
- Handlers implement `IRequestHandler<TRequest, TResponse>`.
- Use Fluent API inside `DbContext.OnModelCreating`, avoid data annotations on domain entities.
- Keep controllers/endpoints thin: delegate execution directly to MediatR (`ISender`).