using CommandCore.Library;
using System;
using System.IO;
using Console = Colorful.Console;

namespace Lartisan
{
    public class Program
    {
        public static string version = "Lartisan 1.0.0";
        public static int Main(string[] args)
        {
            var commandCoreApp = new CommandCoreApp();
            commandCoreApp.ConfigureServices(sp =>
            {
                sp.Register<IOutputWriter, OutputWriter>();
            });
            return commandCoreApp.Parse(args);
        }
    }

    public class OutputWriter : IOutputWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IOutputWriter
    {
        void Write(string message);
    }
}
