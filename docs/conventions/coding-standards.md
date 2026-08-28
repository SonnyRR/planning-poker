---
title: Coding Standards
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: convention
---

# Coding Standards

These rules are **enforced by the build** (see ADR 0007). A change that breaks
them is a broken build — for humans and AI agents alike.

## Mandatory analyzer rules

- `Roslynator.Analyzers` and `SonarAnalyzer.CSharp` run on every build.
- `EnforceCodeStyleInBuild=true` (in `Directory.Build.props`).
- Prefer fixing the root cause over suppressing. When a suppression is truly
  needed, use `GlobalSuppressions.cs` (e.g. `src/BFF/GlobalSuppressions.cs`) or a
  narrowly-scoped, commented `#pragma`.

## Language settings (do not deviate)

- **`Nullable` = disabled** and **`ImplicitUsings` = disabled** project-wide
  (ADR 0010). Write explicit `using` directives; do not enable nullable per file
  without a documented reason.
- `LangVersion=latest` (from `Directory.Packages.props`).
- Target framework is `net10.0` (ADR 0009). Do not downgrade.

## General style expectations

- Match the surrounding file's style (indentation, naming, braces) before
  introducing changes.
- Prefer `Ardalis.GuardClauses` (in `SharedKernel`) for argument validation.
- Use FluentValidation for input models; do not validate by hand in controllers.
- Use Serilog structured logging with correlation IDs; do not `Console.WriteLine`.
- Keep business logic in `Core`; keep controllers/hubs thin.

## Generated code

- Never edit `src/Generated/**/*.g.cs`. Change the source in `Core` and rebuild
  (ADR 0004).

## Secrets

- Never hardcode or commit connection strings, signing keys, or certificates.
- Use configuration / user-secrets / environment variables.

## Before you finish a change

Run `./build.sh` and ensure the build (including analysis) passes.
