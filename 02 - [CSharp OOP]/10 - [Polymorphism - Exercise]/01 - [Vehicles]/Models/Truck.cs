using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITIONER_FUEL_INCREASE = 1.6;

        private const double FUEL_DECREASE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, bool hasAirConditioner = true)
            : base(fuelQuantity, fuelConsumption, hasAirConditioner)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + AIR_CONDITIONER_FUEL_INCREASE;

        public override void Refuel(double amount)
        {
            base.Refuel(amount * FUEL_DECREASE);
        }
    }
}
