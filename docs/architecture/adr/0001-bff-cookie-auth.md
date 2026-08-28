---
title: ADR 0001: Backend-for-Frontend with Cookie Authentication
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: adr
---

# ADR 0001: Backend-for-Frontend with Cookie Authentication

## Status

Accepted

## Context

A Blazor WASM SPA needs to call protected APIs, but storing access tokens in
the browser (localStorage / JS-accessible memory) exposes them to XSS and
complicates logout/revocation. We needed a clean way to authenticate the SPA
without shipping tokens to the client.

## Decision

We use a **Backend-for-Frontend (BFF)** pattern. The `BFF` project:

- Owns the OpenID Connect flow and exchanges the auth code for tokens server-side.
- Issues an **HttpOnly, Secure, SameSite cookie** to the browser.
- Exposes account/logout controllers and a Razor Pages host for the Blazor client.
- Transforms claims (`Utilities/ClaimsTransformer.cs`) before issuing the cookie.

The browser only ever holds the cookie; tokens never reach client JavaScript.

## Consequences

- Positive: tokens are not XSS-exposed; centralized logout/revocation; simpler client.
- Negative: an extra hosting tier; the BFF is a single, security-critical component.
- The WebAPI must validate tokens (not cookies) — see ADR 0002/0007 wiring.

## References

- `src/BFF/` (AccountController, ClaimsTransformer, Pages)
- Complements ADR 0002 (OpenIddict issuer).
