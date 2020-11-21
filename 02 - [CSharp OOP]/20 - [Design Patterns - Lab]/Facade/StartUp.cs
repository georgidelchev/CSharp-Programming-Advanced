using System;
using Facade.Models;

namespace Facade
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                  .WithType("Audi")
                  .WithColor("Black")
                  .WithNumberOfDoors(5)
                .Built
                  .InCity("Sofia")
                  .AtAddress("3")
                .Build();

            Console.WriteLine(car);
        }
    }
}
