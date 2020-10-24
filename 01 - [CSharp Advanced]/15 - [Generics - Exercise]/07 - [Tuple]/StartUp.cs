using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Reading();
            var fullName = $"{input[0]} {input[1]}";
            var address = input[2];

            var myTuple1 = new MyTuple<string, string>(fullName, address);
            Console.WriteLine(myTuple1);

            input = Reading();
            var name = input[0];
            var litersOfBeer = int.Parse(input[1]);
            var myTuple2 = new MyTuple<string, int>(name, litersOfBeer);
            Console.WriteLine(myTuple2);

            input = Reading();
            var num = int.Parse(input[0]);
            var num2 = double.Parse(input[1]);
            var myTuple3 = new MyTuple<int, double>(num, num2);
            Console.WriteLine(myTuple3);
        }

        private static List<string> Reading()
            => Console
                   .ReadLine()
                   .Split()
                   .ToList();
    }
}
