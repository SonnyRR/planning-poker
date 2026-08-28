---
title: ADR 0006: SignalR for Real-Time Collaboration
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: adr
---

# ADR 0006: SignalR for Real-Time Collaboration

## Status
Accepted

## Context
Planning poker is inherently collaborative — participants vote and see results
live. Polling the REST API would be wasteful and laggy.

## Decision
Real-time uses **ASP.NET Core SignalR**, isolated in the `Sockets` project:
- `Sockets` hosts the hubs and real-time contracts.
- The Blazor `Client` connects via `Microsoft.AspNetCore.SignalR.Client`.
- Hubs operate on `Core` domain state and broadcast table/vote updates.

(YARP in `WebAPI` proxies the SignalR traffic to `Sockets` where needed.)

## Consequences
- Positive: low-latency multi-user updates; clean separation in `Sockets`.
- Negative: added scaling concern (sticky sessions / backplane) if scaled out.
- Follow-ups: consider a SignalR backplane (Redis) before multi-instance deploy.

## References
- `src/Sockets/`
- `src/Client/*.csproj` (SignalR.Client)
- ADR 0003
