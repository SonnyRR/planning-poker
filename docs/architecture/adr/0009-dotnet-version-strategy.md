---
title: ADR 0009: Target the Latest .NET (with a Lagging README)
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: adr
---

# ADR 0009: Target the Latest .NET (with a Lagging README)

## Status

Accepted

## Context

The project began on .NET 6. The README and some tribal knowledge still claim
".NET 6", but the codebase has moved on.

## Decision

All projects target **`net10.0`** (see every `src/*/*.csproj` and `build/Build.csproj`).
We track current .NET releases. The root `README.md` is **known-outdated** and
must not be trusted for framework facts — `Directory.Build.props` and the
`.csproj` files are authoritative.

## Consequences

- Positive: modern APIs, performance, and long-term support cadence.
- Negative: the README misleads newcomers and AI agents that read it first.
- Follow-ups: `README.md` has since been updated to state `net10.0` and the
  current library versions, and `AGENTS.md` now points agents to `docs/` as the
  authoritative source while still treating `.csproj`/`Directory.Build.props` as
  ground truth. No further action pending.

## References

- `Directory.Build.props`, all `src/*/*.csproj` (`<TargetFramework>net10.0</TargetFramework>`)
- `README.md` (claims ".NET 6" — inaccurate)
- Repo-root `AGENTS.md` (README warning)
