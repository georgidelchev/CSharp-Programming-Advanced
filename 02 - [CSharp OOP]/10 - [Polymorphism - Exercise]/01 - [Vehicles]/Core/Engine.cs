using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.Interfaces;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Proceed()
        {
            var carData = Reading(this.reader);

            string type;
            double fuelQuantity;
            double fuelConsumption;

            GetArgs(carData, out type, out fuelQuantity, out fuelConsumption);

            IVehicle car = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption);

            var truckData = Reading(this.reader);

            GetArgs(truckData, out type, out fuelQuantity, out fuelConsumption);

            IVehicle truck = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption);

            var commandsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= commandsCount; i++)
            {
                var input = Reading(this.reader);

                var command = input[0];
                var vehicleType = input[1];
                var argument = double.Parse(input[2]);

                if (command == "Drive")
                {
                    DriveVehicle(car, truck, vehicleType, argument);
                }
                else if (command == "Refuel")
                {
                    RefuelVehicle(car, truck, vehicleType, argument);
                }
            }

            Print(car, truck);
        }

        private static List<string> Reading(IReader reader)
                => reader
                   .ReadLine()
                   .Split()
                   .ToList();

        private static void GetArgs(List<string> carData, out string type, out double fuelQuantity, out double fuelConsumption)
        {
            type = carData[0];
            fuelQuantity = double.Parse(carData[1]);
            fuelConsumption = double.Parse(carData[2]);
        }

        private void DriveVehicle(IVehicle car, IVehicle truck, string vehicleType, double argument)
        {
            bool isDrive = false;

            if (vehicleType == "Car")
            {
                isDrive = car.Drive(argument);
            }
            else if (vehicleType == "Truck")
            {
                isDrive = truck.Drive(argument);
            }

            if (isDrive)
            {
                this.writer.WriteLine($"{vehicleType} travelled {argument} km");
            }
            else
            {
                this.writer.WriteLine($"{vehicleType} needs refueling");
            }
        }

        private static void RefuelVehicle(IVehicle car, IVehicle truck, string vehicleType, double argument)
        {
            if (vehicleType == "Car")
            {
                car.Refuel(argument);
            }
            else if (vehicleType == "Truck")
            {
                truck.Refuel(argument);
            }
        }
        
        private void Print(IVehicle car, IVehicle truck)
        {
            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
        }
    }
}
