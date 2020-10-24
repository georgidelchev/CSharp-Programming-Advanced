using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }

            var box = new Box<string>(list);

            Console.WriteLine(box.GetCount(Console.ReadLine()));
        }
    }
}
