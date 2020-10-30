using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class ProgramEngine
    {
        private List<Car> cars;
        private List<Engine> engines;
        private Engine engine;

        public ProgramEngine()
        {
            this.cars = new List<Car>();
            this.engines = new List<Engine>();
            this.engine = null;
        }

        public void Proceed()
        {
            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = GetParameters();

                string model = parameters[0];
                int power = int.Parse(parameters[1]);

                int displacement = -1;
                displacement = AddCar(parameters, model, power, displacement);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = GetParameters();

                string model = parameters[0];
                string engineModel = parameters[1];
                engine = GetEngine(engineModel);

                int weight = -1;
                weight = AddEngine(parameters, model, engine, weight);
            }

            PrintCars();
        }


        private static string[] GetParameters()
        {
            return Console
                .ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private int AddCar(string[] parameters, string model, int power, int displacement)
        {
            if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
            {
                this.engines.Add(new Engine(model, power, displacement));
            }
            else if (parameters.Length == 3)
            {
                string efficiency = parameters[2];
                this.engines.Add(new Engine(model, power, efficiency));
            }
            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
                this.engines.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
            }
            else
            {
                this.engines.Add(new Engine(model, power));
            }

            return displacement;
        }

        private Engine GetEngine(string engineModel)
                => this.engines
                   .FirstOrDefault(x => x.Model == engineModel);

        private int AddEngine(string[] parameters, string model, Engine engine, int weight)
        {
            if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
                this.cars.Add(new Car(model, engine, weight));
            }
            else if (parameters.Length == 3)
            {
                string color = parameters[2];
                this.cars.Add(new Car(model, engine, color));
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                this.cars.Add(new Car(model, engine, int.Parse(parameters[2]), color));
            }
            else
            {
                this.cars.Add(new Car(model, engine));
            }

            return weight;
        }

        private void PrintCars()
        {
            foreach (var car in this.cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
