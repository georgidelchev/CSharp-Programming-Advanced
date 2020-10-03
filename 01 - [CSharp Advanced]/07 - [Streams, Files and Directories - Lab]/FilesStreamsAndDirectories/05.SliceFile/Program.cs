using System;
using System.IO;
using System.Linq;

namespace _05.SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("SliceFile", "SliceMe.txt");
            var reader = new FileStream(path, FileMode.Open);

            var length = reader.Length / 4;
            while (length % 4 != 0)
            {
                length++;
            }
            var buffer = new byte[length];

            for (int i = 1; i <= 4; i++)
            {
                var reading = reader.Read(buffer, 0, buffer.Length);

                if (reading < buffer.Length)
                {
                    buffer = buffer
                        .Take(reading)
                        .ToArray();
                }

                var dir = Path.Combine("SliceFile", $"Part-{i}.txt");
                using (var writer = new FileStream(dir, FileMode.OpenOrCreate))
                {
                    writer.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
