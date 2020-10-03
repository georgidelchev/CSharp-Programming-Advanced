using System;
using System.IO;

namespace FilesStreamsAndDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("OddLines", "input.txt");
            var dir = Path.Combine("OddLines", "output.txt");

            using (var reader = new StreamReader(path))
            {
                using (var writer = new StreamWriter(dir))
                {
                    int counter = 0;

                    string input = "";
                    while ((input = reader.ReadLine()) != null)
                    {
                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(input);
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
