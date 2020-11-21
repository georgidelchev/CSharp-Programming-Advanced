using System;
using AbstractClassTwo.Models;

namespace AbstractClassTwo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var sourdough = new Sourdough();
            sourdough.Make();
            Console.WriteLine();

            var twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            Console.WriteLine();

            var wholeWheat = new WholeWheat();
            wholeWheat.Make();
            Console.WriteLine();
        }
    }
}
