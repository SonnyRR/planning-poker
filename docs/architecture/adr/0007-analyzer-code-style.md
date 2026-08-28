---
title: ADR 0007: Analyzer-Enforced Code Style
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: adr
---

# ADR 0007: Analyzer-Enforced Code Style

## Status

Accepted

## Context

Inconsistent style and subtle bugs creep in across many projects. We wanted
quality gates enforced automatically, not by peer review alone, and crucially
**enforced for AI-generated changes too**.

## Decision

Code style is enforced **at build time**:

- `Directory.Build.props` sets `EnforceCodeStyleInBuild=true`.
- `Directory.Packages.props` adds `Roslynator.Analyzers` and `SonarAnalyzer.CSharp`
  as `PrivateAssets=all` analyzers.
- Warnings are treated as build-breaking where configured.

A change (human or AI) that violates analysis is, by definition, a broken build.

## Consequences

- Positive: uniform style; fewer bug classes; AI edits held to the same bar.
- Negative: stricter iteration; some legitimate patterns need suppressions.
- Use `GlobalSuppressions.cs` (see BFF) or justified `#pragma` rather than
  disabling rules globally.

## References

- `Directory.Build.props` (`EnforceCodeStyleInBuild`)
- `Directory.Packages.props` (analyzer packages)
- `src/BFF/GlobalSuppressions.cs`
- `conventions/coding-standards.md`
