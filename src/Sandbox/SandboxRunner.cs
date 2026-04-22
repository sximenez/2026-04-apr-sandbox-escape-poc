using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

[assembly: InternalsVisibleTo("SandboxEscapePoc.Tests")]
namespace SandboxEscapePoc.Sandbox
{
    record SandboxRequest(string UntrustedCode, SandboxPolicy Policy);
    // Question: Shouldn't we use the Result pattern here?
    record SandboxResult(bool Succeeded, string Output, string? Error);

    static class SandboxRunner
    {
        public static async Task<SandboxResult> Handle(SandboxRequest request)
        {
            try
            {
                ScriptOptions options = ScriptOptions.Default
                    .WithReferences(typeof(object).Assembly)
                    .WithImports("System");

                string result = await CSharpScript.EvaluateAsync<string>(request.UntrustedCode, options);

                return new SandboxResult(true, result ?? string.Empty, null);
            }
            catch (Exception ex)
            {
                return new SandboxResult(false, string.Empty, ex.Message);
            }
        }
    }
}