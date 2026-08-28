---
title: Documentation Index
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: index
---

# Documentation Index

This directory is the canonical source of truth for humans **and** AI agents
working on Planning Poker. `AGENTS.md` (repo root) links here.

```txt
docs/
├── README.md                      # This file — the map of the map
├── architecture/
│   ├── overview.md                # System architecture, request flow, layers
│   └── adr/                       # Architecture Decision Records (MADR format)
│       ├── 0000-template.md       # Copy this to start a new ADR
│       ├── 0001-bff-cookie-auth.md
│       ├── 0002-openiddict-identity.md
│       ├── 0003-blazor-wasm-client.md
│       ├── 0004-code-generation.md
│       ├── 0005-fluxor-state.md
│       ├── 0006-signalr-realtime.md
│       ├── 0007-analyzer-code-style.md
│       ├── 0008-nuke-gitversion.md
│       ├── 0009-dotnet-version-strategy.md
│       └── 0010-nullable-implicitusings-off.md
├── conventions/
│   ├── coding-standards.md        # Style rules enforced by analyzers
│   └── development-workflow.md     # Build, run, migrate, add features
└── project-map.md                 # What each src/* project owns
```

## How to use this as an AI agent

1. Start at repo-root `AGENTS.md`.
2. For *why* something is the way it is → read the matching ADR.
3. For *how* to do a recurring task → `conventions/development-workflow.md`.
4. For *what* a project contains → `project-map.md` + `architecture/overview.md`.

## Adding a new ADR

Copy `architecture/adr/0000-template.md` to `NNNN-kebab-title.md`, fill it in,
and link it from `AGENTS.md` and this index. ADRs are append-only: supersede,
never rewrite history (add a "Status: Superseded by NNNN" note).
