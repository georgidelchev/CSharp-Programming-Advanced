using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                set.Add(input);
            }

            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
