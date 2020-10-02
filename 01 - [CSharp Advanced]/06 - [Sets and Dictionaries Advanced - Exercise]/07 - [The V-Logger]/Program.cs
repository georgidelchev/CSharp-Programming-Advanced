using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVlogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = "";
            while ((input = Console.ReadLine()) != "Statistics")
            {
                var splittedInput = input
                    .Split()
                    .ToList();

                string firstVloggerName = splittedInput[0];
                string command = splittedInput[1];

                switch (command)
                {
                    case "joined":
                        if (!dict.ContainsKey(firstVloggerName))
                        {
                            dict[firstVloggerName] = new Dictionary<string, SortedSet<string>>();

                            dict[firstVloggerName]["followers"] = new SortedSet<string>();
                            dict[firstVloggerName]["followings"] = new SortedSet<string>();
                        }
                        break;
                    case "followed":
                        string secondVloggerName = splittedInput[2];

                        if (dict.ContainsKey(firstVloggerName) &&
                            dict.ContainsKey(secondVloggerName))
                        {
                            if (!(firstVloggerName == secondVloggerName))
                            {
                                dict[firstVloggerName]["followings"].Add("*  " + secondVloggerName);
                                dict[secondVloggerName]["followers"].Add("*  " + firstVloggerName);
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {dict.Count()} vloggers in its logs.");

            dict = dict
                .OrderByDescending(x => x.Value["followers"].Count())
                .ThenBy(x => x.Value["followings"].Count())
                .ToDictionary(x => x.Key, x => x.Value);

            int counter = 1;
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value["followers"].Count} followers, {kvp.Value["followings"].Count} following");

                if (counter == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, kvp.Value["followers"]));
                }

                counter++;
            }
        }
    }
}
