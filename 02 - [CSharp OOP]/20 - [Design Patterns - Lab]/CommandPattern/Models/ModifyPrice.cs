using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Contracts;

namespace CommandPattern.Models
{
    public class ModifyPrice
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;

        public ModifyPrice()
        {
            this._commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            this._command = command;
        }

        public void Invoke()
        {
            this._commands.Add(this._command);
            this._command.ExecuteAction();
        }
    }
}
