using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var regulars = new HashSet<string>();
            var vips = new HashSet<string>();

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "PARTY")
                {
                    while ((input = Console.ReadLine()) != "END")
                    {
                        if (regulars.Contains(input))
                        {
                            regulars.Remove(input);
                        }
                        if (vips.Contains(input))
                        {
                            vips.Remove(input);
                        }
                    }

                    break;
                }
                else
                {
                    if (input[0] >= 48 && input[0] <= 57)
                    {
                        vips.Add(input);
                    }
                    else
                    {
                        regulars.Add(input);
                    }
                }
            }
            if (input == "END")
            {
                Console.WriteLine(regulars.Count() + vips.Count());
                if (vips.Count() > 0)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, vips));
                }
                if (regulars.Count() > 0)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, regulars));
                }
            }

        }
    }
}
