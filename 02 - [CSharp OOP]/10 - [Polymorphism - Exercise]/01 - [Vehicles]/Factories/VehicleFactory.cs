using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, bool hasAirConditioner = true)
        {
            IVehicle vehicle = null;

            switch (type)
            {
                case nameof(Car):
                    vehicle = new Car(fuelQuantity, fuelConsumption, hasAirConditioner);
                    break;
                case nameof(Truck):
                    vehicle = new Truck(fuelQuantity, fuelConsumption, hasAirConditioner);
                    break;
            }

            return vehicle;
        }
    }
}
