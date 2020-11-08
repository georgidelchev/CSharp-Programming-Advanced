using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.ExceptionsMessages;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITIONER_FUEL_INCREASE = 1.6;

        private const double FUEL_DECREASE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true)
            : base(fuelQuantity, fuelConsumption, tankCapacity, hasAirConditioner)
        {
        }

        public override double AirConditionerIncrease => AIR_CONDITIONER_FUEL_INCREASE;

        public override void Refuel(double amount)
        {
            ExceptionMessage.CheckFuelQuantity(this.FuelQuantity, amount, this.TankCapacity);

            base.Refuel(amount * FUEL_DECREASE);
        }
    }
}
