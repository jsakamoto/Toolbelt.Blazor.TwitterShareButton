#nullable enable
using System;
using System.IO;
using System.Threading;
using static Toolbelt.Blazor.TwitterShareButton.Test.Internals.Shell;

namespace Toolbelt.Blazor.TwitterShareButton.Test.Internals
{
    public class WorkSpace : IDisposable
    {
        public string WorkSpaceDir { get; }

        public string StartupProj { get; }

        public string Bin { get; }

        public string Obj { get; }

        public static WorkSpace Create(string startupProjDir)
        {
            return new WorkSpace(startupProjDir);
        }

        public static string GetSolutionDir()
        {
            var solutionDir = AppDomain.CurrentDomain.BaseDirectory;
            do { solutionDir = Path.GetDirectoryName(solutionDir); } while (!Exists(solutionDir, "*.sln"));
            return solutionDir!;
        }

        private WorkSpace(string startupProjDir)
        {
            WorkSpaceDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid().ToString("N"));

            var solutionDir = GetSolutionDir();
            var sampleSitesDir = Path.Combine(solutionDir, "SampleSites");
            XcopyDir(sampleSitesDir, WorkSpaceDir, excludesDir: new[] { ".vs", "bin", "obj" });

            var nugetConfigPath = Path.Combine(WorkSpaceDir, "nuget.config");
            if (File.Exists(nugetConfigPath)) File.Delete(nugetConfigPath);

            StartupProj = Path.Combine(WorkSpaceDir, startupProjDir);
            Bin = Path.Combine(StartupProj, "bin");
            Obj = Path.Combine(StartupProj, "obj");
        }

        public void Dispose()
        {
            for (var i = 0; i < 5; i++)
            {
                try
                {
                    if (Directory.Exists(WorkSpaceDir)) Delete(WorkSpaceDir);
                    break;
                }
                catch (Exception) { Thread.Sleep(200); }
            }
        }
    }
}
