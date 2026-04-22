using System;
using System.Threading.Tasks;
using SandboxEscapePoc.Sandbox;

namespace SandboxEscapePoc.Stages
{
    // Question: What is the purpose of the Stage1_BasicIsolation class in this code?
    static class Stage1_BasicIsolation
    {
        public static async Task RunAsync()
        {
            Console.WriteLine("------- Stage 1 — Basic Isolation -------");

            SandboxResult result = await SandboxRunner.Handle(new SandboxRequest(
                UntrustedCode: """System.IO.File.ReadAllText("secrets.txt")""",
                Policy: SandboxPolicy.Strict
            ));

            Console.WriteLine(result.Succeeded
                ? $"BREACH: file access not blocked. Output: {result.Output}"
                : $"HELD:   file access blocked. Error: {result.Error}");
        }
    }
}