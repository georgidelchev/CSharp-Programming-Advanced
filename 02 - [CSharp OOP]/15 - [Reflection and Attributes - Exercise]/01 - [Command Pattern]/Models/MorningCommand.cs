using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Models
{
    public class MorningCommand : ICommand
    {
        public string Execute(string[] args)
        {
            var result = $"Good morning, {args[0]}";

            return result;
        }
    }
}
