---
title: ADR 0002: Self-Hosted OpenIddict Identity Server
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: adr
---

# ADR 0002: Self-Hosted OpenIddict Identity Server

## Status

Accepted

## Context

The system needs an OAuth2/OIDC token issuer for the BFF (ADR 0001) and for
WebAPI token validation (ADR 0007). Options: a hosted IdP (Auth0 / Azure AD B2C)
or a self-hosted server embedded in the solution.

## Decision

We self-host **OpenIddict** inside the `Identity` project:

- `OpenIddict.AspNetCore` + `OpenIddict.EntityFrameworkCore` for issuing tokens.
- `OpenIddict.Quartz` to prune/rotate tokens via scheduled jobs.
- Built on ASP.NET Core Identity (`Microsoft.AspNetCore.Identity.EntityFrameworkCore`).

The WebAPI consumes `OpenIddict.Validation.AspNetCore` (+ `SystemNetHttp`) to
validate those tokens — no external IdP dependency.

## Consequences

- Positive: zero external IdP cost/lock-in; full control over flows & stores.
- Negative: we own hardening, key management, and uptime of the issuer.
- Follow-ups: secrets/certificates must stay out of source control.

## References

- `src/Identity/*.csproj`, OpenIddict packages
- ADR 0001 (consumer), ADR 0007 (validation side)
