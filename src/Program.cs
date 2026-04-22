using System.Threading.Tasks;
using SandboxEscapePoc.Stages;

namespace SandboxEscapePoc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Stage1_BasicIsolation.RunAsync();
        }
    }
}