using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tiresList = new List<Tire[]>();

            string input = "";
            while ((input = Console.ReadLine()) != "No more tires")
            {
                var splitted = input
                    .Split()
                    .Select(double.Parse)
                    .ToList();

                Tire[] tires = new Tire[4];

                for (int i = 0; i < splitted.Count; i += 2)
                {
                    int tireYear = (int)splitted[i];
                    double tirePressure = splitted[i + 1];

                    tires[i / 2] = new Tire(tireYear, tirePressure);
                }

                tiresList.Add(tires);
            }

            var enginesList = new List<Engine>();

            while ((input = Console.ReadLine()) != "Engines done")
            {
                var splitted = input
                    .Split()
                    .Select(double.Parse)
                    .ToList();

                for (int i = 0; i < splitted.Count; i += 2)
                {
                    int engineHorsePower = (int)splitted[0];
                    double engineCubicCapacity = splitted[1];

                    var currentEngine = new Engine(engineHorsePower, engineCubicCapacity);
                    enginesList.Add(currentEngine);
                }
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                var splitted = input
                    .Split()
                    .ToList();

                string carMake = splitted[0];
                string carModel = splitted[1];
                int carYear = int.Parse(splitted[2]);
                double carFuelQuantity = double.Parse(splitted[3]);
                double carFuelConsumption = double.Parse(splitted[4]);
                int carEngineIndex = int.Parse(splitted[5]);
                int carTireIndex = int.Parse(splitted[6]);

                var car = new Car(carMake, carModel, carYear, carFuelQuantity, carFuelConsumption, enginesList[carEngineIndex], tiresList[carTireIndex]);

                double sum = 0;

                foreach (var item in car.Tires)
                {
                    sum += item.Pressure;
                }

                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && (sum >= 9 && sum <= 10))
                {
                    car.Drive(20);

                    Console.WriteLine(car.TotalCarInformation());
                }
            }
        }
    }
}
