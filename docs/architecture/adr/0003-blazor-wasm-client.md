---
title: ADR 0003: Blazor WebAssembly Client
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: adr
---

# ADR 0003: Blazor WebAssembly Client

## Status
Accepted

## Context
The UI must be rich, component-based, and share C# types with the backend to
reduce duplication. Options: Blazor Server, Blazor WASM, or a JS SPA (React/Angular).

## Decision
The client is a **Blazor WebAssembly** SPA (`src/Client`):
- UI via **Radzen.Blazor** components.
- Client state via **Fluxor** (see ADR 0005).
- Real-time via `Microsoft.AspNetCore.SignalR.Client` (see ADR 0006).
- Auth integration via `Microsoft.AspNetCore.Components.WebAssembly.Authentication`.
- Logged in/out and served through the BFF's Razor Pages host (ADR 0001).

## Consequences
- Positive: C# end-to-end, code-shared DTOs (`Generated`), offline-capable shell.
- Negative: larger initial download than Server; WASM constraints.
- The BFF remains the auth broker — the client never handles raw tokens.

## References
- `src/Client/*.csproj`
- ADR 0001, ADR 0005, ADR 0006
