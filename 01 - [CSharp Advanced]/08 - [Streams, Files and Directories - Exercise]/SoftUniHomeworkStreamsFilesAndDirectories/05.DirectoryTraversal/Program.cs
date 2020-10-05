using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = ".";
            var path = Path.Combine("./");

            var files = Directory.GetFiles(path, $"*{input}*");

            var data = new Dictionary<string, Dictionary<string, double>>();

            foreach (var item in files)
            {
                var fileInfo = new FileInfo(item);

                var fileName = fileInfo.Name;
                var fileExtension = fileInfo.Extension;
                var fileSize = fileInfo.Length;

                if (!data.ContainsKey(fileExtension))
                {
                    data[fileExtension] = new Dictionary<string, double>();
                }

                if (!data[fileExtension].ContainsKey(fileName))
                {
                    data[fileExtension][fileName] = fileSize;
                }
            }

            var sb = new StringBuilder();

            foreach (var item in data
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                var fileExtension = item.Key;

                sb.AppendLine(fileExtension);

                foreach (var secondItem in item.Value
                    .OrderBy(x => x.Value))
                {
                    var fileName = secondItem.Key;
                    var fileSize = secondItem.Value / 1024.0;

                    sb.AppendLine($"--{fileName} - {fileSize:f3}kb");
                }
            }

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var dirPath = Path.Combine(desktopPath, "report.txt");

            File.WriteAllText(dirPath, sb.ToString());
        }
    }
}
