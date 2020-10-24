using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Reading();
            var fullName = $"{input[0]} {input[1]}";
            var address = input[2];
            var town = string.Join(" ", input, 3, input.Length - 3);

            var myTuple1 = new MyThreeuple<string, string, string>(fullName, address, town);
            Console.WriteLine(myTuple1);

            input = Reading();
            var name = input[0];
            var litersOfBeer = int.Parse(input[1]);
            bool drunk = input[2] == "drunk" ? true : false;
            var myTuple2 = new MyThreeuple<string, int, bool>(name, litersOfBeer, drunk);
            Console.WriteLine(myTuple2);

            input = Reading();
            var currName = input[0];
            var accBalance = double.Parse(input[1]);
            var bankName = input[2];
            var myTuple3 = new MyThreeuple<string,double,string>(currName, accBalance, bankName);
            Console.WriteLine(myTuple3);
        }

        private static string[] Reading()
            => Console
                   .ReadLine()
                   .Split()
                   .ToArray();
    }
}
