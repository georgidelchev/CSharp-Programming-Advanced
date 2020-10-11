using System;

namespace CarManufacturer
{
    public class Car
    {
        private int year;

        public Car()
            : this("VW", "Golf", 2025, 200, 10)
        {

        }

        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(int distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (this.FuelQuantity - neededFuel <= 0)
            {
                throw new InvalidOperationException("No fuel!");
            }

            this.FuelQuantity -= neededFuel;
        }

        public string TotalCarInformation()
        {
            return $"Make: {this.Make}{Environment.NewLine}" +
            $"Model: {this.Model}{Environment.NewLine}" +
            $"Year: {this.Year}{Environment.NewLine}" +
            $"FuelQuantity: {this.FuelQuantity}";
        }
    }
}
