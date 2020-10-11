using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(2020,3),
                new Tire(2020,3),
                new Tire(2020,3),
                new Tire(2020,3)
            };

            var engine = new Engine(800, 12.0);

            var car = new Car("Audi", "A4", 2020, 250, 100, engine, tires);
        }
    }
}
