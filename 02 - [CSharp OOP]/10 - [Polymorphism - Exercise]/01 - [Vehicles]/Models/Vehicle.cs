using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, bool hasAirConditioner = true)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.HasAirConditioner = hasAirConditioner;
        }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; private set; }

        public bool HasAirConditioner { get; private set; }

        public bool Drive(double distance)
        {
            double neededFuel = this.FuelConsumption * distance ;

            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                return true;
            }

            return false;
        }

        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}