using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Models
{
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var tokens = args
                .Split()
                .ToArray();

            var commandName = tokens[0];
            var fullCommandName = commandName + "Command";

            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.GetInterfaces().Any(x => x.Name == nameof(ICommand)))
                .FirstOrDefault(x => x.Name == fullCommandName);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            ICommand command = Activator.CreateInstance(type) as ICommand;

            var clearData = tokens
                .Skip(1)
                .ToArray();

            var result = command.Execute(clearData);

            return result;
        }
    }
}
