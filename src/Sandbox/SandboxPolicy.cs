namespace SandboxEscapePoc.Sandbox
{
    // Question: What is the purpose of the SandboxPolicy record in this code?
    record SandboxPolicy(
        bool AllowFileSystem,
        bool AllowReflection,
        bool AllowNetwork
    )
    {
        public static SandboxPolicy Strict => new SandboxPolicy(
                AllowFileSystem: false,
                AllowReflection: false,
                AllowNetwork: false
        );
    }
}