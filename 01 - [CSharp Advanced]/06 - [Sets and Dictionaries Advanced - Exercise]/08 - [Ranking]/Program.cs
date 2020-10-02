using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVlogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestsAndPasswords = new Dictionary<string, string>();

            string input = "";
            while ((input = Console.ReadLine()) != "end of contests")

            {
                var inputSplitted = input
                    .Split(":")
                    .ToList();

                string contest = inputSplitted[0];
                string password = inputSplitted[1];

                if (!contestsAndPasswords.ContainsKey(contest))
                {
                    contestsAndPasswords[contest] = password;
                }
            }

            var users = new Dictionary<string, Dictionary<string, double>>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var inputSplitted = input
                    .Split("=>")
                    .ToList();

                string contest = inputSplitted[0];
                string password = inputSplitted[1];
                string username = inputSplitted[2];
                double points = double.Parse(inputSplitted[3]);

                if (contestsAndPasswords.ContainsKey(contest))
                {
                    if (contestsAndPasswords[contest] == password)
                    {
                        if (!users.ContainsKey(username))
                        {
                            users[username] = new Dictionary<string, double>();
                        }

                        if (!users[username].ContainsKey(contest))
                        {
                            users[username][contest] = 0;
                        }

                        if (points > users[username][contest])
                        {
                            users[username][contest] = points;
                        }
                    }
                }
            }

            var best = new Dictionary<string, double>();

            foreach (var kvp in users)
            {
                best[kvp.Key] = kvp.Value.Values.Sum();
            }

            best = best
                .OrderByDescending(x => x.Value)
                .Take(1)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Best candidate is {string.Join("", best.Keys)} with total {string.Join("", best.Values)} points.");

            Console.WriteLine("Ranking:");

            foreach (var kvp in users
                .OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var kvp2 in kvp.Value
                    .OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp2.Key} -> {kvp2.Value}");
                }
            }
        }
    }
}
