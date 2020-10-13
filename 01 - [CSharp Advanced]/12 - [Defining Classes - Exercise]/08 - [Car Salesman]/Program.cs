using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Engine engine = null;

            var enginesList = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                var engineInformation = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string engineModel = engineInformation[0];
                int enginePower = int.Parse(engineInformation[1]);

                int engineDisplacement = 0;
                string engineEfficiency = "n/a";

                string result = "n/a";
                if (engineInformation.Count == 3)
                {
                    bool canParse = int.TryParse(engineInformation[2], out engineDisplacement);
                    if (canParse)
                    {
                        result = engineDisplacement.ToString();
                    }
                    else
                    {
                        engineEfficiency = engineInformation[2];
                    }
                }
                if (engineInformation.Count == 4)
                {
                    engineDisplacement = int.Parse(engineInformation[2]);
                    result = engineDisplacement.ToString();
                    engineEfficiency = engineInformation[3];
                }

                engine = new Engine(engineModel, enginePower, result, engineEfficiency);
                enginesList.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            Car car = null;
            var carsList = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                var carInformation = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string carModel = carInformation[0];
                string engineModel = carInformation[1];

                int carWeight = 0;
                string carColor = "n/a";

                string result = "n/a";
                if (carInformation.Count == 3)
                {
                    bool canParse = int.TryParse(carInformation[2], out carWeight);
                    if (canParse)
                    {
                        result = carWeight.ToString();
                    }
                    else
                    {
                        carColor = carInformation[2];
                    }
                }
                if (carInformation.Count == 4)
                {
                    carWeight = int.Parse(carInformation[2]);
                    result = carWeight.ToString();
                    carColor = carInformation[3];
                }

                Engine currentEngine = enginesList.FirstOrDefault(x => x.Model == engineModel);

                car = new Car(carModel, currentEngine, result, carColor);

                carsList.Add(car);
            }

            foreach (var item in carsList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
