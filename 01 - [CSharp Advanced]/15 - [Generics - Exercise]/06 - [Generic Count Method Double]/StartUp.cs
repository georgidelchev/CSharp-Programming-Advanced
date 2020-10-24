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

            var list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<double>(list);

            Console.WriteLine(box.GetCount(double.Parse(Console.ReadLine())));
        }
    }
}
