using SandboxEscapePoc.Sandbox;

namespace SandboxEscapePoc.Tests
{
    public class Stage1Tests
    {
        [Fact]
        public async Task FileAccess_UnderStrictPolicy_IsBlocked()
        {
            SandboxResult result = await SandboxRunner.Handle(new SandboxRequest(
                UntrustedCode: """System.IO.File.ReadAllText("secrets.txt")""",
                Policy: SandboxPolicy.Strict
            ));

            Assert.False(result.Succeeded);
            Assert.NotNull(result.Error);
        }

        [Fact]
        public async Task SafeCode_UnderStrictPolicy_Executes()
        {
            SandboxResult result = await SandboxRunner.Handle(new SandboxRequest(
                UntrustedCode: """(1 + 1).ToString()""",
                Policy: SandboxPolicy.Strict
            ));

            Assert.True(result.Succeeded);
            Assert.Equal("2", result.Output);
        }
    }
}