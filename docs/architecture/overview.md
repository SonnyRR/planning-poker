---
title: Architecture Overview
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: architecture
---

# Architecture Overview

Planning Poker is a layered, secure-by-default .NET system. The defining trait
is that the **browser never talks to a token issuer directly** — a BFF brokers
auth with cookies, while a separate OpenIddict server issues tokens for
server-to-server (BFF → WebAPI) validation.

## High-level components

```txt
┌─────────────────────────────────────────────────────────────┐
│ Browser (Blazor WASM Client)                                 │
│  - Fluxor state  - Radzen UI  - SignalR client               │
└───────────────┬───────────────────────────┬─────────────────┘
                │ HTTPS (cookie)            │ WSS (SignalR)
                ▼                           ▼
        ┌──────────────┐            ┌──────────────┐
        │   BFF        │            │   Sockets    │  (real-time hub)
        │ (cookie auth)│            │  (SignalR)   │
        └──────┬───────┘            └──────┬───────┘
               │ token (server-to-server)  │
               ▼                           ▼
        ┌──────────────┐            ┌──────────────┐
        │   WebAPI     │◀─ YARP ────│  (proxied)   │
        │  REST + val  │            └──────────────┘
        └──────┬───────┘
               ▼
        ┌──────────────┐   ┌──────────────┐   ┌──────────────┐
        │   Core       │◀─▶│ Persistence  │   │   Identity   │
        │  domain      │   │  EF Core     │   │ OpenIddict   │
        └──────────────┘   └──────────────┘   └──────────────┘
```

## Request flows

### 1. Authentication (sign-in)

1. User hits BFF `AccountController` → redirected to `Identity` (OpenIddict).
2. OpenIddict authenticates via ASP.NET Identity, issues auth code → BFF.
3. BFF exchanges code, sets an **HttpOnly, SameSite cookie**, transforms claims.
4. Browser now sends the cookie on every BFF/WebAPI call.

### 2. REST call (Client → data)

1. Client calls WebAPI over the cookie-authenticated channel.
2. WebAPI validates the token (OpenIddict validation) and serves data from
   `Core`/`Persistence`.
3. DTOs cross the boundary as `Generated` models (mapped via Mapster).

### 3. Real-time (live voting)

1. Client opens a SignalR connection to `Sockets`.
2. `Core` domain events push table/vote state to all connected participants.

## Cross-cutting concerns

- **Logging:** Serilog everywhere (console + Seq), correlated via CorrelationId.
- **Code generation:** `Core` entities → DTOs/mappers in `Generated` (Mapster.Tool, build-time).
- **Build/versioning:** NUKE (`build/`) + GitVersion (`GitVersion.yml`, GitHubFlow).
- **Analysis:** Roslynator + SonarAnalyzer enforced in every build.

## Boundaries to respect

- Domain logic belongs in `Core`; do not put business rules in `WebAPI` controllers.
- DTOs are `Generated`; domain entities are in `Core`. Map between them, never merge.
- The BFF is the only place that handles cookies; WebAPI only validates tokens.

See `project-map.md` for per-project ownership and `adr/` for the reasoning.
