---
title: Project Map
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: reference
---

# Project Map

Each project under `src/` has a single, well-scoped responsibility. Dependencies
flow "inward" toward `Core` / `SharedKernel`; nothing outside those should
depend on infrastructure concerns directly.

| Project | Responsibility |
| --- | --- |
| `SharedKernel` | Cross-cutting primitives shared by every project (base types, guards, result/error abstractions). No dependencies on other `src/*` projects. |
| `Core` | Domain model, business rules, and abstractions (interfaces/repositories). Depends on `SharedKernel`. Contains the **source of truth** for entities that get code-generated into DTOs. |
| `Persistence` | EF Core `DbContext`, migrations, entity configurations. Implements `Core` repository abstractions. SQL Server provider. |
| `Identity` | Self-hosted OpenIddict identity server: token issuance, ASP.NET Identity, Quartz-backed flows. Owns its own `DbContext`/stores. |
| `Generated` | **Build-time generated** DTOs and Mapster mappers (`.g.cs`). Never edit by hand. Regenerated from `Core` models by the NUKE build (`Mapster.Tool`). |
| `Sockets` | SignalR hubs and real-time contracts for live collaboration (voting, table state). |
| `WebAPI` | REST API: controllers/endpoints, YARP reverse-proxy, OpenIddict *validation*, Serilog. Sits in front of `Core`/`Persistence`/`Sockets`. |
| `BFF` | Backend-for-Frontend: cookie auth, account/logout controllers, Razor Pages host for the Blazor client, claims transformation. Bridges the browser to the identity server. |
| `Client` | Blazor WebAssembly SPA. Fluxor state, Radzen UI, SignalR client, calls WebAPI. Depends on `Generated` DTOs. |

## Dependency direction (mental model)

```txt
Client ─▶ BFF ─▶ (Identity)  ┐
   │                          ├─▶ WebAPI ─▶ Sockets
   └─(SignalR)────────────────┘              │
                                             ▼
                                  Core ◀─ Persistence
                                    ▲
                              SharedKernel
```

- `Generated` is produced *from* `Core` and *consumed by* `Client` (+ API).
- The BFF issues cookies; the WebAPI validates tokens issued by `Identity`.
- Infrastructure (EF, OpenIddict, SignalR) lives behind `Core` abstractions.

## Solution file

`PlanningPoker.slnx` lists all 9 `src/*` projects plus the `build/` NUKE project.
