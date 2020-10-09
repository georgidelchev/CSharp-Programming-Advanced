using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            var nums = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<int, List<int>, List<int>> addNumbersFunc = (x, y) =>
             {
                 var list = new List<int>();

                 for (int i = 1; i <= end; i++)
                 {
                     bool isValid = true;

                     for (int j = 0; j < y.Count; j++)
                     {
                         if (!(i % y[j] == 0))
                         {
                             isValid = false;
                         }
                     }

                     if (isValid)
                     {
                         list.Add(i);
                     }
                 }

                 return list;
             };

            var numsList = addNumbersFunc(end, nums);


            Console.WriteLine(string.Join(" ", numsList));
        }
    }
}
