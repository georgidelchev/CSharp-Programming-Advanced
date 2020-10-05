using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("LineNumbers", "text.txt");
            var dir = Path.Combine("LineNumbers", "output.txt");

            var file = File.ReadAllLines(path).ToList();
            for (int i = 0; i < file.Count; i++)
            {
                var lettersPattern = @"[A-Za-z]";
                var lettersCount = Regex.Matches(file[i], lettersPattern);

                var punctsPattern = @"[\.\,\!\?\-\']";
                var punctsCount = Regex.Matches(file[i], punctsPattern);

                file[i] = $"Line {i + 1}:{file[i]} ({lettersCount.Count})({punctsCount.Count})";

                Console.WriteLine(file[i]);
            }

            File.WriteAllLines(dir, file);
        }
    }
}
