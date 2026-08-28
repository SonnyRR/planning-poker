---
title: ADR 0010: Nullable and ImplicitUsings Disabled
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: adr
---

# ADR 0010: Nullable and ImplicitUsings Disabled

## Status
Accepted

## Context
Modern C# defaults to nullable reference types and implicit global usings. While
helpful, enabling them project-by-project in a mature, analyzer-strict codebase
risks large-scale churn and inconsistent behavior across the 9 projects.

## Decision
**`Nullable` and `ImplicitUsings` are disabled project-wide** via
`Directory.Build.props` (`<Nullable>disable</Nullable>`,
`<ImplicitUsings>disable</ImplicitUsings>`).

Consequences for contributors and AI agents:
- All `using` directives must be explicit — do not rely on implicit global usings.
- Do not add `#nullable enable` per file unless there is a documented, reviewed
  reason; consistency across the solution is the priority.

## Consequences
- Positive: uniform, predictable compilation; no half-migrated nullable states.
- Negative: more verbose files; misses some null-safety assistance.
- Any future move to nullable should be a deliberate, repo-wide ADR-driven change.

## References
- `Directory.Build.props`
- `conventions/coding-standards.md`
