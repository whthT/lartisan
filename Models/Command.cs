using System;
using System.Collections.Generic;
using System.Text;

namespace Lartisan.Models
{
    class Command
    {
        public string name;
        public List<Command> subCommands;
        public bool isParentCommand;

        public Command(string _name, List<Command> _subCommands, bool _isParentCommand)
        {
            name = _name;
            isParentCommand = _isParentCommand;
            subCommands = _isParentCommand ? _subCommands : new List<Command>();
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string _name)
        {
            name = _name;
        }


        public List<Command> GetSubCommands()
        {
            return subCommands;
        }

        public void SetSubCommands(List<Command> _subCommands)
        {
            subCommands = _subCommands;
        }

        public void AddSubCommand(Command subCommand)
        {
            subCommands.Add(subCommand);
        }
    }
}
