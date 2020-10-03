using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("TestFolder");
            var dirs = Directory.GetDirectories("TestFolder");

            double sum = 0;
            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                Console.WriteLine(file + Environment.NewLine + fi.Length);
                Console.WriteLine();

                sum += fi.Length;
            }
            sum = sum / 1024 / 1024;
            File.WriteAllText("output.txt", "Size: " + sum.ToString() + " MB");
        }
    }
}
