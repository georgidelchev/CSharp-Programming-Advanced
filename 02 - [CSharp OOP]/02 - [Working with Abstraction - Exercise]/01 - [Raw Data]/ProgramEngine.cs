using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public class ProgramEngine
    {
        private List<Car> cars;

        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        private List<string> fragile;
        private List<string> flamable;

        public ProgramEngine()
        {
            this.cars = new List<Car>();
            this.engine = null;
            this.cargo = null;
            this.tires = null;
            this.fragile = new List<string>();
            this.flamable = new List<string>();
        }

        public void Proceed()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = GetParameters();

                this.engine = CreateEngine(parameters);

                this.cargo = CreateCargo(parameters);
                this.tires = CreateTires(parameters);

                this.cars.Add(CreateCar(parameters));
            }

            string command = Console.ReadLine();

            Printing(command);
        }

        private static string[] GetParameters()
                => Console
                   .ReadLine()
                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        public Engine CreateEngine(string[] parameters)
        {
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);

            return new Engine(engineSpeed, enginePower);
        }

        public Cargo CreateCargo(string[] parameters)
        {
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            return new Cargo(cargoWeight, cargoType);
        }

        public Tire[] CreateTires(string[] parameters)
        {
            double tire1Pressure = double.Parse(parameters[5]);
            int tire1Age = int.Parse(parameters[6]);

            double tire2Pressure = double.Parse(parameters[7]);
            int tire2Age = int.Parse(parameters[8]);

            double tire3Pressure = double.Parse(parameters[9]);
            int tire3Age = int.Parse(parameters[10]);

            double tire4Pressure = double.Parse(parameters[11]);
            int tire4Age = int.Parse(parameters[12]);

            return new Tire[]
            {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age)
            };
        }

        public Car CreateCar(string[] parameters)
        {
            string carModel = parameters[0];

            return new Car(carModel, this.engine, this.cargo, this.tires);
        }

        private void FilteringFragiles()
                => this.fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

        private void FilteringFlamables()
                 => this.flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

        private void Printing(string command)
        {
            if (command == "fragile")
            {
                FilteringFragiles();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                FilteringFlamables();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
