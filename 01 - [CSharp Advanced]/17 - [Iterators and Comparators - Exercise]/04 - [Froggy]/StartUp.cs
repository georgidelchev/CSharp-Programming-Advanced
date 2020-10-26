using System;
using System.Linq;

namespace Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var lake = new Lake(input);

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
