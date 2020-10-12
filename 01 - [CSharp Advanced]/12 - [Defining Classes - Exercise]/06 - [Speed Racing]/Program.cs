using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());

            Car car = null;
            var carsList = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string carModel = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer = double.Parse(input[2]);

                car = new Car(carModel, fuelAmount, fuelConsumptionPerKilometer);
                
                carsList.Add(car);
            }

            string secondInput = "";
            while ((secondInput = Console.ReadLine()) != "End")
            {
                var splitted = secondInput
                    .Split()
                    .ToList();

                string carModel = splitted[1];
                double amountOfKm = double.Parse(splitted[2]);

                var currentCar = carsList.Find(x => x.Model == carModel);

                currentCar.CanCarMoveTheDistance(amountOfKm);
            }

            foreach (var item in carsList)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TravelledDistance}");
            }
        }
    }
}
