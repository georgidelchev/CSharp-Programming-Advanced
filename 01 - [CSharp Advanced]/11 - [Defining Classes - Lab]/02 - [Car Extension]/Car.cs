using System;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double neededFuel = fuelConsumption * distance;

            if (this.fuelQuantity - neededFuel <= 0)
            {
                throw new InvalidOperationException("Not enough fuel!");
            }

            this.fuelQuantity -= neededFuel;
        }

        public string TotalCarInformation()
        {
            return $"Make: {this.Make}{Environment.NewLine}" +
                $"Model: {this.Model}{Environment.NewLine}" +
                $"Year: {this.Year}{Environment.NewLine}" +
                $"Fuel: {this.FuelQuantity:f2}";
        }
    }
}
