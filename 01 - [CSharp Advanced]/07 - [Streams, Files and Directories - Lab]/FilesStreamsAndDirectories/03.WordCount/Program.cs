using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsPath = Path.Combine("WordCount", "words.txt");
            var inputPath = Path.Combine("WordCount", "input.txt");
            var dir = Path.Combine("WordCount", "output.txt");

            var words = new List<string>();
            var inputWords = new Dictionary<string, int>();

            using (var reader = new StreamReader(wordsPath))
            {
                words = reader
                    .ReadLine()
                    .Split()
                    .ToList();
            }

            for (int i = 0; i < words.Count; i++)
            {
                if (!inputWords.ContainsKey(words[i]))
                {
                    inputWords[words[i]] = 0;
                }
            }

            using (var reader = new StreamReader(inputPath))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    var splitted = line
                        .Split(new char[] { '-', ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToList();

                    for (int i = 0; i < splitted.Count; i++)
                    {
                        if (inputWords.ContainsKey(splitted[i]))
                        {
                            inputWords[splitted[i]]++;
                        }
                    }
                }
            }
            using (var writer = new StreamWriter(dir))
            {
                foreach (var kvp in inputWords
                    .OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
