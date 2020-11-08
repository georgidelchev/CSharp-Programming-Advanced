using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITIONER_FUEL_INCREASE = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, hasAirConditioner)
        {
        }

        public override double AirConditionerIncrease => AIR_CONDITIONER_FUEL_INCREASE;
    }
}
