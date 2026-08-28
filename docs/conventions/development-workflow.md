---
title: Development Workflow
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: convention
---

# Development Workflow

The single supported entry point for building and verifying is the NUKE build.

## Build & verify

```bash
./build.sh          # Linux/macOS
build.cmd           # Windows
```

This compiles all projects, runs code generation (ADR 0004), and enforces
analyzers (ADR 0007). **Do not** rely on bare `dotnet build` / `dotnet test` —
the NUKE pipeline is the source of truth, and CI runs exactly `./build.sh`.

> There are **no test projects** in the repo today. Don't invent tests to claim
> verification; state explicitly when code needs manual/integration checking.

## Run locally

- The BFF hosts the Blazor client and brokers auth (ADR 0001). Start the BFF and
  the WebAPI (and Identity) as configured in the solution. Use `launchSettings.json`
  under each project for profiles.
- Real-time requires the `Sockets` (SignalR) project reachable behind WebAPI/YARP.

## Database & migrations (EF Core)

Commands assume you are in the repo root. The Persistence project owns migrations;
WebAPI is the startup project.

```bash
# Apply migrations
dotnet ef database update \
  -p src/Persistence/PlanningPoker.Persistence.csproj \
  -s src/WebAPI/PlanningPoker.WebAPI.csproj

# Add a migration
dotnet ef migrations add "MyMigration" \
  -p src/Persistence/PlanningPoker.Persistence.csproj \
  -s src/WebAPI/PlanningPoker.WebAPI.csproj
```

(Requires the global `dotnet-ef` tool — see repo-root `docs/README.md`.)

## Adding a feature end-to-end (recommended flow)

1. **Domain** — add the entity/rule in `Core` (`src/Core`). This is the source of
   truth that code-gen reads.
2. **Persistence** — add EF configuration/migrations in `Persistence` if the entity
   is stored.
3. **Generated DTOs** — rebuild (`build.sh`); Mapster.Tool regenerates DTOs and
   mappers in `Generated`. Do not hand-edit `.g.cs`.
4. **API** — expose the feature via WebAPI controllers (validate tokens) or
   `Sockets` hubs for real-time parts.
5. **Client** — consume `Generated` DTOs in the Blazor `Client`; add a **Fluxor**
   feature for any new state (ADR 0005); wire SignalR if real-time (ADR 0006).
6. **Build** — run `./build.sh`; fix any analyzer errors before considering done.

## Identity / OpenIddict notes

- The `Identity` project is the token issuer (ADR 0002). Scaffold Identity UI via
  the ASP.NET Core code generator if pages need changes (see `docs/README.md`).
- Keep signing keys/certs out of source control.

## Versioning & CI

- GitVersion (`GitVersion.yml`, GitHubFlow) derives versions from git history.
- CI (`.github/workflows/ci.yml`) runs `./build.sh` on push/PR to `master`.
