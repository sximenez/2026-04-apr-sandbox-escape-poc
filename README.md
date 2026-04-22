# Sandbox Escape Poc
**A sandboxing study -- to complete**

References: [Has Mythos just broken the deal that kept the internet safe?, Martin Alderson](https://martinalderson.com/posts/has-mythos-just-broken-the-deal-that-kept-the-internet-safe/)

---

## Table of Contents

---

## Theory

## Practice

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