---
title: ADR 0008: NUKE Build Automation and GitVersion
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: adr
---

# ADR 0008: NUKE Build Automation and GitVersion

## Status
Accepted

## Context
Build, code generation, migration, and versioning were at risk of becoming a
pile of ad-hoc shell scripts that differ per machine and per CI runner.

## Decision
All build orchestration lives in a **NUKE** build project (`build/Build.csproj`):
- Single cross-platform entry point: `./build.sh` (and `build.cmd`/`build.ps1`).
- The build drives code generation (ADR 0004), compilation, and analysis.
- **GitVersion** (`GitVersion.yml`, `GitHubFlow/v1`) derives semantic versions
  from git history. CI (`.github/workflows/ci.yml`) invokes `./build.sh`.

## Consequences
- Positive: reproducible local/CI builds; one command; traceable versions.
- Negative: learning curve for NUKE; build logic lives in C#.
- **There is no supported ad-hoc `dotnet build`/`dotnet test` path** — always use
  `./build.sh`. AI agents must run `./build.sh`, not raw `dotnet` commands.

## References
- `build/` (NUKE project), `build.sh`, `build.cmd`, `build.ps1`
- `GitVersion.yml`
- `.github/workflows/ci.yml`
