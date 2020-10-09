using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleList = Console
                .ReadLine()
                .Split()
                .ToList();

            string input = "";
            while ((input = Console.ReadLine()) != "Party!")
            {
                var splitted = input
                    .Split()
                    .ToList();

                string command = splitted[0];
                string subCommand = splitted[1];

                Predicate<string> predicate = subCommand switch
                {
                    "StartsWith" => x => x.StartsWith(splitted[2]),
                    "EndsWith" => x => x.EndsWith(splitted[2]),
                    "Length" => x => x.Length == int.Parse(splitted[2]),
                };

                for (int i = 0; i < peopleList.Count; i++)
                {
                    if (predicate(peopleList[i]))
                    {
                        if (command == "Remove")
                        {
                            peopleList.RemoveAll(predicate);

                        }
                        else if (command == "Double")
                        {
                            peopleList.Insert(i + 1, peopleList[i]);
                            i++;
                        }
                    }
                }
            }

            if (peopleList.Any())
            {
                Console.WriteLine(string.Join(", ", peopleList) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
