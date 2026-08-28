---
title: ADR 0005: Fluxor for Client State Management
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: adr
---

# ADR 0005: Fluxor for Client State Management

## Status

Accepted

## Context

The Blazor client needs predictable, testable UI state (current table, votes,
connection status). Options: hand-rolled `CascadingParameter`/`Observable`, or a
Redux-style store.

## Decision

We use **Fluxor** (`Fluxor.Blazor.Web` + `Fluxor.Blazor.Web.ReduxDevTools`):

- Single store, feature slices, actions/effects/reducers.
- Redux DevTools integration for debugging.

## Consequences

- Positive: unidirectional data flow; devtools; decoupled from components.
- Negative: more boilerplate per feature (feature, state, actions, reducers).
- New client features should add a Fluxor feature rather than ad-hoc state.

## References

- `src/Client/*.csproj` (Fluxor packages)
- ADR 0003 (client framework)
