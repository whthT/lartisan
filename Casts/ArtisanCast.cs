using Lartisan.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lartisan.Casts
{
    class ArtisanCast
    {
        private List<string> lines;
        private string laravelVersion;
        private List<Command> availableCommands;
        public ArtisanCast(string[] _lines)
        {
            lines = new List<string>(_lines);

            laravelVersion = lines[0];
            availableCommands = GenerateAvailableCommands();
        }

        public List<string> GetLines()
        {
            return lines;
        }

        public string GetLaravelVersion()
        {
            return laravelVersion;
        }

        private List<Command> GenerateAvailableCommands()
        {
            var commands = new List<Command>();
            var beginToRecordCommands = false;
            var index = 0;
            foreach (string line in lines)
            {
                var isCommandsStarting = line == "Available commands:";
                if (isCommandsStarting)
                {
                    beginToRecordCommands = true;
                }

                if (beginToRecordCommands && !isCommandsStarting)
                {
                    var explodes = line.Split(" ");

                    var isParentCommand = !String.IsNullOrEmpty(explodes[1]);
                    var name = isParentCommand ? explodes[1] : explodes[2];
                    if (isParentCommand)
                    {
                        var subCommands = new List<Command>();
                        foreach (string _line in lines.GetRange(index + 1, lines.Count() - index - 1))
                        {
                            var subExplodes = _line.Split(" ");
                            var isSubCommand = String.IsNullOrEmpty(subExplodes[1]);
                            
                            if (isSubCommand)
                            {
                                subCommands.Add(
                                    new Command(subExplodes[2], new List<Command>(), false)
                                );
                            } else
                            {
                                break;
                            }
                        }
                        commands.Add(new Command(name, subCommands, true));
                    }
                    
                }
                index++;
            }
            var json = JsonConvert.SerializeObject(commands);
            Console.WriteLine(json);
            return commands;
        }

        public List<Command> GetAvailableCommands()
        {
            return availableCommands;
        }

    }
}
