using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lartisan.Casts
{
    class ArtisanCast
    {
        private string[] lines;
        private string laravelVersion;
        private List<string> availableCommands;
        public ArtisanCast(string[] _lines)
        {
            lines = _lines;
            laravelVersion = lines[0];
            availableCommands = GenerateAvailableCommands();
        }

        public string[] GetLines()
        {
            return lines;
        }

        public string GetLaravelVersion()
        {
            return laravelVersion;
        }

        private List<string> GenerateAvailableCommands()
        {
            var commands = new List<string>();
            var beginToRecordCommands = false;
            foreach (string line in GetLines())
            {
                if (line == "Available commands:")
                {
                    beginToRecordCommands = true;
                }

                if (beginToRecordCommands)
                {
                    commands.Add(line);
                }
            }
            commands.RemoveAt(0);
            return commands;
        }

        public List<string> GetAvailableCommands()
        {
            return availableCommands;
        }

    }
}
