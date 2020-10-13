using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Car car = null;
            Engine engine = null;
            Cargo cargo = null;
            List<Tire> tire = null;

            var carsList = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                // Model of the car;
                string carModel = input[0];

                // Engine args;
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);

                engine = new Engine(engineSpeed, enginePower);

                // Cargo args;
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                cargo = new Cargo(cargoWeight, cargoType);

                // First tire args;
                double firstTirePressure = double.Parse(input[5]);
                int firstTireYear = int.Parse(input[6]);

                // Second tire args;
                double secondTirePressure = double.Parse(input[7]);
                int secondTireYear = int.Parse(input[8]);

                // Third tire args;
                double thirdTirePressure = double.Parse(input[9]);
                int thirdTireYear = int.Parse(input[10]);

                // Forth tire args;
                double forthTirePressure = double.Parse(input[11]);
                int forthTireYear = int.Parse(input[12]);

                tire = new List<Tire>
                {
                    new Tire(firstTireYear, firstTirePressure),
                    new Tire(secondTireYear, secondTirePressure),
                    new Tire(thirdTireYear, thirdTirePressure),
                    new Tire(forthTireYear, forthTirePressure)
                };

                car = new Car(carModel, engine, cargo, tire);

                carsList.Add(car);
            }

            string command = Console.ReadLine();

            Func<List<Car>, List<Car>> func = x => command switch
             {
                 "fragile" => x
                 .Where(c => c.Cargo.CargoType == "fragile" && c.Tire.Any(t => t.TirePressure < 1))
                 .ToList(),

                 "flamable" => x
                 .Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250)
                 .ToList(),
             };

            carsList = func(carsList).ToList();

            foreach (var item in carsList)
            {
                Console.WriteLine(item.Model);
            }
        }
    }
}
