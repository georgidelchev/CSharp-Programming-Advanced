using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITIONER_FUEL_INCREASE = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, bool hasAirConditioner = true)
            : base(fuelQuantity, fuelConsumption, hasAirConditioner)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + AIR_CONDITIONER_FUEL_INCREASE;
    }
}
