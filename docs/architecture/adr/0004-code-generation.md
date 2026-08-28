---
title: ADR 0004: Code-Generated DTOs and Mappers
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: adr
---

# ADR 0004: Code-Generated DTOs and Mappers

## Status
Accepted

## Context
Every domain entity in `Core` needs a wire DTO plus a Mapster mapping profile.
Hand-writing and maintaining these is error-prone and repetitive, and risks the
API contract drifting from the domain model.

## Decision
DTOs and mappers are **generated at build time** into the separate
`src/Generated` project:
- `Mapster.Tool` (declared in `build/Build.csproj`) scans `Core` models and emits
  `*.g.cs` under `src/Generated/Models` and `src/Generated/Mapping`.
- The generated `DataTransferObjectRegister` wires the mappers.
- `Generated` references `Mapster` and ships the `.g.cs` artifacts for the
  `Client` and `WebAPI` to consume.

**The `*.g.cs` files are never edited by hand** — change the source model or the
mapping configuration and regenerate via `./build.sh`.

## Consequences
- Positive: DTOs cannot drift from the domain; no hand-written boilerplate.
- Negative: a build step is required to see changes; generated output is opaque.
- Follow-ups: when adding an entity, update `Core` and rerun the build (see
  `development-workflow.md` → "Adding a feature end-to-end").

## References
- `src/Generated/` (`.g.cs` files, `DataTransferObjectRegister.cs`)
- `build/Build.csproj` (`Mapster.Tool` package download)
- `src/Core/*.csproj` (`Mapster` reference)
