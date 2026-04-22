# Sandbox Escape Poc
**A sandboxing study -- to complete**

References: [Has Mythos just broken the deal that kept the internet safe?, Martin Alderson](https://martinalderson.com/posts/has-mythos-just-broken-the-deal-that-kept-the-internet-safe/)

---

## Table of Contents

---

## Theory

### Sandboxing

A sandbox is an isolated execution environment where code can be run with restricted permissions.

If code is untrusted or dangerous, the sandbox prevents it from reaching outside and causing harm.

Access to the host system or other processes (e.g., filesystem, network, memory) is denied, unless explicitly allowed.

This makes sandboxing the cornerstone of modern security.

Trust boundaries are enforced as contracts between the sandbox and the other layers of the system.

### Escape

Modern devices stack multiple sandbox layers and contracts.

Our current security model relies on the assumption that these layers are secure and that the contracts between them are upheld.

As of 2026, Anthropic's Mythos Preview has breached these in more than 74% of trials on Firefox's JS shell,

up from 1% for the previous generation.

The issue here is the trajectory: with huge amounts of compute, LLMs are now capable of breaking the decades-long security model.

## Practice

### Objective

The goal of this project is to explore the concept of sandbox escape in a controlled environment.

We build a minimal sandbox in C# and deliberately break it — stage by stage:

| Stage | What we build | What we learn |
|---|---|---|
| 1 — Basic Isolation | Roslyn script runs in restricted AssemblyLoadContext | Why reference restriction blocks filesystem access |
| 2 — Capability Leak | Host leaks a `FileStream` reference into the sandbox | Why object leaks bypass permission checks |
| 3 — Reflection Exploit | Script uses reflection to reach `AppDomain` | Why reflection breaks isolation without permission grants |
| 4 — Patched Sandbox | Policy strips dangerous API surface at compile time | Why removing access beats blocking actions |

Each stage is a concrete instance of the trust boundary failure the article describes.

### Structure

### Setup

```terminal
dotnet new sln -n sandbox-escape-poc
dotnet new console -n SandboxEscapePoc -o src
dotnet new xunit -n SandboxEscapePoc.Tests -o tests

dotnet sln add src/SandboxEscapePoc.csproj
dotnet sln add tests/SandboxEscapePoc.Tests.csproj

dotnet add tests/SandboxEscapePoc.Tests.csproj reference src/SandboxEscapePoc.csproj

# Roslyn scripting
dotnet add src/SandboxEscapePoc.csproj package Microsoft.CodeAnalysis.CSharp.Scripting
```

---