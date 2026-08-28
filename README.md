---
title: Planning Poker
status: active
author: AI coding agent (opencode) on behalf of Vasil Kotsev
created: 2026-08-28
last_reviewed: 2026-08-28
review_cycle: per-release
type: project-readme
---

<img src="./src/Client/wwwroot/images/logo.svg" height="55" width="184">

ℹ This is a Blazor WASM application for planning & estimating tasks for the Scrum Agile methodology. It is intended to showcase what a modern, secure and clean system with a Blazor front-end should look like. It utilizes OIDC with a custom identity server, BFF and Cookie based authentication, code generation for models & their mappers, fluent validations, state management with Fluxor and more.

[![CI](https://github.com/SonnyRR/planning-poker/actions/workflows/ci.yml/badge.svg)](https://github.com/SonnyRR/planning-poker/actions/workflows/ci.yml)

> 📚 **For contributors and AI agents:** the authoritative guidance lives in
> [`AGENTS.md`](./AGENTS.md) and [`docs/`](./docs/README.md) (architecture, ADRs,
> conventions). This README is a high-level overview only.

# 🛠 Built with
* .NET 10 (`net10.0`)
* Blazor WebAssembly
* Radzen.Blazor (11.2.8)
* EF Core 10 (SQL Server)
* ASP.NET Core WebAPI
* ASP.NET Identity Core + OpenIddict (7.6.1)
* NUKE Automated Build System
* Fluxor (6.11.0)
* Mapster (10.1.0)
* OpenIddict (7.6.1) + Quartz (3.20.0)
* Serilog (+ CorrelationId)
* YARP Reverse Proxy (2.3.0)
* SignalR
* FluentValidation (12.1.1)
