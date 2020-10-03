using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("LineNumbers", "input.txt");
            var dir = Path.Combine("LineNumbers", "output.txt");

            using (var reader = new StreamReader(path))
            {
                using (var writer = new StreamWriter(dir))
                {
                    int counter = 1;

                    string input = "";
                    while ((input = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{counter}.  {input}");
                        counter++;
                    }
                }
            }
        }
    }
}
