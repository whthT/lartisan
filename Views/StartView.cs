using CommandCore.Library.PublicBase;
using Lartisan.Casts;
using Lartisan.Options;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Console = Colorful.Console;

namespace Lartisan.Views
{
    class StartView : VerbViewBase
    {
        private readonly StartOptions _options;
        private readonly IOutputWriter _writer;
        private string projectName;
        private char seperator;

        public StartView(StartOptions options, IOutputWriter writer)
        {
            _options = options;
            _writer = writer;
            projectName = Path.GetFileName(options.ProjectDir);
            seperator = Path.DirectorySeparatorChar;
        }

        private ArtisanCast GenerateArtisanOutput()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            var projectLartisanDirectoryAbsPath = $"{_options.ProjectDir}{seperator}.lartisan";
            var projectArtisanOutputAbsPath = $"{projectLartisanDirectoryAbsPath}{seperator}out.txt";

            if (!Directory.Exists(projectLartisanDirectoryAbsPath))
            {
                Directory.CreateDirectory(projectLartisanDirectoryAbsPath);
            }

            cmd.StandardInput.WriteLine($"php {_options.ProjectDir}\\artisan > {projectLartisanDirectoryAbsPath}{seperator}out.txt");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            var lines = File.ReadAllLines(@projectArtisanOutputAbsPath);
            return new ArtisanCast(lines);
        }

        public override void RenderResponse()
        {
            var artisanCast = GenerateArtisanOutput();

            Console.WriteLine(artisanCast.GetLaravelVersion(), Color.Orange);
            Console.WriteLine(Program.version, Color.Green);
            var availableCommands = artisanCast.GetAvailableCommands();
            Console.WriteLine(String.Join("\n", availableCommands));
        }
    }
}
