using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace AppleAndOrange
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = Console
                .ReadLine()
                .Split(' ')
                .ToList();

            int s = int.Parse(st[0]);
            int t = int.Parse(st[1]);

            var ab = Console
                .ReadLine()
                .Split(' ')
                .ToList();

            int a = int.Parse(ab[0]);
            int b = int.Parse(ab[1]);

            var mn = Console
                .ReadLine()
                .Split(' ')
                .ToList();

            int m = int.Parse(mn[0]);
            int n = int.Parse(mn[1]);

            var apples = Array
                .ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp));

            var oranges = Array
                .ConvertAll(Console.ReadLine().Split(' '), orangesTemp => Convert.ToInt32(orangesTemp));

            int applesCount = 0;
            for (int i = 0; i < m; i++)
            {
                int applePos = a + apples[i];

                if (applePos >= s && applePos <= t)
                {
                    applesCount++;
                }
            }

            int orangesCount = 0;
            for (int i = 0; i < n; i++)
            {
                int orangePos = b + oranges[i];

                if (orangePos >= s && orangePos <= t)
                {
                    orangesCount++;
                }
            }

            Console.WriteLine(applesCount);
            Console.WriteLine(orangesCount);
        }
    }
}
