---
title: AGENTS.md — Planning Poker
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: agent-entry
---

# AGENTS.md — Planning Poker

This file is the **entry point for AI coding agents** (OpenCode, Claude, Copilot, Cursor, …).
Read it fully before making changes, then read the linked docs as needed.

## What this project is
A Blazor WebAssembly planning-poker app for Agile estimation. It is a reference
implementation of a modern, secure .NET system: a custom OpenIddict identity
server, a Backend-for-Frontend (BFF) with cookie auth, a REST WebAPI behind YARP,
real-time collaboration over SignalR, and a Fluxor-managed Blazor client.

> 📌 The root `README.md` gives a high-level stack overview; `docs/` (below) is
> authoritative for how to work in this repo. When `README.md` and code disagree,
> trust `Directory.Build.props` / the `.csproj` files.

## Read these, in order, when starting work
1. `docs/architecture/overview.md` — how the pieces fit together.
2. `docs/project-map.md` — what each `src/*` project is responsible for.
3. `docs/architecture/adr/` — past decisions and *why* they were made.
4. `docs/conventions/coding-standards.md` — style rules you **must** follow.
5. `docs/conventions/development-workflow.md` — build, run, migrate, add features.

## Hard rules (do not violate)
- **Match existing code style.** Style is enforced at build time via Roslynator
  and SonarAnalyzer (`EnforceCodeStyleInBuild=true` in `Directory.Build.props`).
  A change that fails analysis is a broken build.
- **Never hand-edit generated code.** Everything under `src/Generated/**/*.g.cs`
  is produced by the build (Mapster.Tool). Edit the source models/maps instead.
- **Keep `Nullable` and `ImplicitUsings` OFF** project-wide (set in
  `Directory.Build.props`). Do not add `using` statements implicitly or enable
  nullable per-file without a documented reason.
- **No secrets.** Do not commit connection strings, keys, or certificates.
- **Prefer the existing layered flow** when adding features (see
  `development-workflow.md` → "Adding a feature end-to-end").
- **Do not invent tests.** There are currently **no test projects** in the
  repo. If you add code that needs verification, say so explicitly rather than
  fabricating a test suite.

## Build & verify
```bash
./build.sh        # NUKE build (the only sanctioned build entry point)
```
CI runs `./build.sh` on `master` / PRs (`.github/workflows/ci.yml`).
There is no ad-hoc `dotnet test` step — the NUKE pipeline defines verification.

## Architecture decisions at a glance
- **BFF + cookie auth** over direct SPA token flow → `adr/0001-bff-cookie-auth.md`
- **Self-hosted OpenIddict** identity server → `adr/0002-openiddict-identity.md`
- **Blazor WASM** client → `adr/0003-blazor-wasm-client.md`
- **Generated DTOs/mappers** in a separate project → `adr/0004-code-generation.md`
- **Fluxor** client state → `adr/0005-fluxor-state.md`
- **SignalR** real-time via `Sockets` → `adr/0006-signalr-realtime.md`
- **Strict analyzers** → `adr/0007-analyzer-code-style.md`
- **NUKE + GitVersion** → `adr/0008-nuke-gitversion.md`
- **Track latest .NET** → `adr/0009-dotnet-version-strategy.md`
- **Nullable/ImplicitUsings disabled** → `adr/0010-nullable-implicitusings-off.md`

When in doubt, an ADR outranks this file, which outranks tribal knowledge.
If you make a new decision, add an ADR (copy `adr/0000-template.md`).
