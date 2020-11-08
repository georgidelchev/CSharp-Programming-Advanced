using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        bool HasAirConditioner { get; }

        bool Drive(double distance);

        void Refuel(double amount);

        void TurnOnAirConditioner();

        void TurnOffAirConditioner();
    }
}
