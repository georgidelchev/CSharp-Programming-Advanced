using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("EvenLines", "text.txt");
            var dir = Path.Combine("EvenLines", "output.txt");

            var charsToReplace = new char[] { '-', ',', '.', '!', '?' };

            char charForReplacing = '@';
            using (var reader = new StreamReader(path))
            {
                var line = "";
                int counter = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (counter++ % 2 == 0)
                    {
                        var replacedString = charsToReplace
                        .Aggregate(line, (x1, x2) => x1.Replace(x2, charForReplacing))
                        .Split()
                        .ToList();

                        replacedString.Reverse();

                        using (var writer = new StreamWriter(dir, true))
                        {
                            Console.Write(string.Join(" ", replacedString));
                            writer.Write(string.Join(" ", replacedString));

                            Console.WriteLine();
                            writer.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
