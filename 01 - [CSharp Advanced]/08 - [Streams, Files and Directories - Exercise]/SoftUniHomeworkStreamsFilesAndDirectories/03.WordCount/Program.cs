using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsPath = Path.Combine("WordCount", "words.txt");
            var textPath = Path.Combine("WordCount", "text.txt");

            var actualResultPath = Path.Combine("WordCount", "actualResult.txt");
            var expectedResultPath = Path.Combine("WordCount", "expectedResult.txt");

            var words = File.ReadAllLines(wordsPath);
            var text = File.ReadAllLines(textPath);

            var dict = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (!dict.ContainsKey(words[i]))
                {
                    dict[words[i]] = 0;
                }
            }

            for (int i = 0; i < text.Length; i++)
            {
                var line = text[i]
                    .Split(new char[] { '-', ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToLower())
                    .ToList();

                for (int j = 0; j < line.Count; j++)
                {
                    if (dict.ContainsKey(line[j]))
                    {
                        dict[line[j]]++;
                    }
                }

            }

            var sb = new StringBuilder();

            bool isOrdered = false;
            WritingToArray(dict, sb, isOrdered);
            File.WriteAllText(actualResultPath, sb.ToString());

            isOrdered = true;
            WritingToArray(dict, sb, isOrdered);
            File.WriteAllText(expectedResultPath, sb.ToString());
        }

        private static StringBuilder WritingToArray(Dictionary<string, int> dict, StringBuilder sb, bool isOrdered)
        {
            int counter = 0;
            sb.Clear();

            if (isOrdered)
            {
                dict = dict
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
            }

            foreach (var item in dict)
            {
                sb.AppendLine(item.Key + " - " + item.Value);
                counter++;
            }

            return sb;
        }
    }
}
