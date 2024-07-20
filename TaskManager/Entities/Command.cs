using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Enums;

namespace TaskManager.Entities
{
    internal class Command
    {
        public CommandEnum CommandName { get; set; }
        public string Parameter { get; set; }

        public Command(CommandEnum commandName, string parameter)
        {
            CommandName = commandName;
            Parameter = parameter;
        }

        public Command(CommandEnum commandName)
        {
            CommandName = commandName;
        }
    }
}
