using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songsList = Console
                .ReadLine()
                .Split(", ")
                .ToList();

            var songsQueue = new Queue<string>(songsList);

            while (songsQueue.Any())
            {
                var commands = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string command = commands[0];

                switch (command)
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;
                    case "Add":
                        commands.RemoveAt(0);

                        string songName = string.Join(" ", commands);

                        if (!songsQueue.Contains(songName))
                        {
                            songsQueue.Enqueue(songName);
                        }
                        else
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songsQueue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
