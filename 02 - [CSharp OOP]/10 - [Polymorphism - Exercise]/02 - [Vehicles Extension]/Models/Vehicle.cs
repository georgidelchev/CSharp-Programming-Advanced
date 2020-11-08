using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.ExceptionsMessages;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const double DEFAULT_FUEL_QUANTITY = 0;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.HasAirConditioner = hasAirConditioner;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = DEFAULT_FUEL_QUANTITY;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        public bool HasAirConditioner { get; private set; }

        public virtual double AirConditionerIncrease { get; private set; }

        public bool Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (this.HasAirConditioner)
            {
                neededFuel += this.AirConditionerIncrease * distance;
            }

            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                return true;
            }

            return false;
        }

        public virtual void Refuel(double amount)
        {
            ExceptionMessage.CheckFuelQuantity(this.FuelQuantity, amount, this.TankCapacity);

            this.FuelQuantity += amount;
        }

        public void TurnOnAirConditioner()
        {
            this.HasAirConditioner = true;
        }

        public void TurnOffAirConditioner()
        {
            this.HasAirConditioner = false;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}