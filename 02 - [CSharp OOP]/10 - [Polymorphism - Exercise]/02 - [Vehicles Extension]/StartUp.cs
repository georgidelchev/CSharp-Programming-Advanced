using System;
using Vehicles.Core;
using Vehicles.Factories;
using Vehicles.Interfaces;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            Engine engine = new Engine(reader, writer, vehicleFactory);

            engine.Proceed();
        }
    }
}
