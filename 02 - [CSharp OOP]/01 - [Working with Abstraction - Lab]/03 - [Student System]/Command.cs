using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentData
{
    public class Command
    {
        /// <summary>
        /// Parsing the command.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Command Parse(string text)
        {
            var parts = text.Split();

            if (parts.Length == 0)
            {
                return null;
            }

            return new Command
            {
                CommandType = parts[0],
                CommandArgs = parts.Skip(1).ToList()
            };
        }

        public string CommandType { get; set; }

        public List<string> CommandArgs { get; set; }
    }
}
