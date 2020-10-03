using System;
using System.IO;
using System.Linq;

namespace _04.MergeFIles
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPath = Path.Combine("MergeFiles", "input1.txt");
            var secondPath = Path.Combine("MergeFiles", "input2.txt");
            var dir = Path.Combine("MergeFiles", "output.txt");

            var file = File.ReadAllLines(firstPath).ToList();
            file.AddRange(File.ReadAllLines(secondPath));
            file.Sort();
            File.WriteAllLines(dir, file);
        }
    }
}
