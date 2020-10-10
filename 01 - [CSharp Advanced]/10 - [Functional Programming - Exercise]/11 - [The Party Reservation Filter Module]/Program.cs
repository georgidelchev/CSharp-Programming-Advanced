using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleList = Console
                .ReadLine()
                .Split()
                .ToList();

            var filters = new List<string>();

            string input = "";
            while ((input = Console.ReadLine()) != "Print")
            {
                var splitted = input
                    .Split(";")
                    .ToList();

                string command = splitted[0];
                string subCommand = splitted[1];

                switch (command)
                {
                    case "Add filter":
                        filters.Add(subCommand + ";" + splitted[2]);
                        break;
                    case "Remove filter":
                        if (filters.Contains(subCommand + ";" + splitted[2]))
                        {
                            filters.Remove(subCommand + ";" + splitted[2]);
                        }
                        break;
                }
            }

            foreach (var item in filters)
            {
                var splitted = item
                    .Split(";")
                    .ToList();

                var currentCommand = splitted[0];

                Predicate<string> func = currentCommand switch
                {
                    "Starts with" => x => x.StartsWith(splitted[1]),
                    "Ends with" => x => x.EndsWith(splitted[1]),
                    "Length" => x => x.Length == int.Parse(splitted[1]),
                    "Contains" => x => x.Contains(splitted[1]),
                    _ => null
                };

                peopleList.RemoveAll(func);
            }

            Console.WriteLine(string.Join(" ", peopleList));
        }
    }
}
