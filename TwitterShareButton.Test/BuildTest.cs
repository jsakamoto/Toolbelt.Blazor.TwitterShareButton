using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Toolbelt.Blazor.TwitterShareButton.Test.Internals;
using static Toolbelt.Blazor.TwitterShareButton.Test.Internals.Shell;
using static Toolbelt.Diagnostics.XProcess;

namespace Toolbelt.Blazor.TwitterShareButton.Test
{
    [Parallelizable(ParallelScope.Children)]
    public class BuildTest
    {
        public static IEnumerable<object[]> Projects = new[] {
            // startupProjName, targetFramework
            new object[]{ "Client",   "net5.0" },
            new object[]{ "Host",     "net5.0"  },
            new object[]{ "Server",   "net5.0" },
            new object[]{ "Client31", "netstandard2.1" },
            new object[]{ "Host",     "netcoreapp3.1"  },
            new object[]{ "Server",   "netcoreapp3.1" },
        };

        private static string CombinePath(string path1, string path2) => Path.Combine(path1.Split('/').Concat(path2.Split('/')).ToArray());

        [Test]
        [TestCaseSource(nameof(Projects))]
        public async Task PublishTest(string startupProjDir, string targetFramework)
        {
            using var workSpace = WorkSpace.Create(startupProjDir);
            var staticWebAssetDir = CombinePath(workSpace.Bin, $"Release/{targetFramework}/publish/wwwroot/_content/Toolbelt.Blazor.TwitterShareButton");

            using var publishProcess = await Start(
                "dotnet",
                $"publish -c:Release -p:BlazorEnableCompression=false -f:{targetFramework}",
                workSpace.StartupProj).WaitForExitAsync();
            publishProcess.ExitCode.Is(0, message: publishProcess.Output);

            // Support client JavaScript file should be published.
            Directory.Exists(staticWebAssetDir).IsTrue();
            Exists(staticWebAssetDir, "script.js").IsTrue();
            Exists(staticWebAssetDir, "script.module.js").IsTrue();
            Exists(staticWebAssetDir, "script.module.min.js").IsTrue();
        }
    }
}
