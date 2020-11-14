using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Models
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            var result = $"Hello, {args[0]}";

            return result;
        }
    }
}
