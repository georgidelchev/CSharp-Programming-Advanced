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
            double tankCapacity;

            GetArgs(carData, out type, out fuelQuantity, out fuelConsumption, out tankCapacity);

            IVehicle car = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);

            var truckData = Reading(this.reader);

            GetArgs(truckData, out type, out fuelQuantity, out fuelConsumption, out tankCapacity);

            IVehicle truck = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);

            var busData = Reading(this.reader);

            GetArgs(busData, out type, out fuelQuantity, out fuelConsumption, out tankCapacity);

            IVehicle bus = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);

            var commandsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= commandsCount; i++)
            {
                var input = Reading(this.reader);

                var command = input[0];
                var vehicleType = input[1];
                var argument = double.Parse(input[2]);
                try
                {
                    ExecuteCommand(car, truck, bus, command, vehicleType, argument);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }

            Print(car, truck, bus);
        }

        private static List<string> Reading(IReader reader)
                => reader
                   .ReadLine()
                   .Split()
                   .ToList();

        private void ExecuteCommand(IVehicle car, IVehicle truck, IVehicle bus, string command, string vehicleType, double argument)
        {
            if (command == "Drive")
            {
                DriveVehicle(command, car, truck, bus, vehicleType, argument);
            }
            else if (command == "DriveEmpty")
            {
                DriveVehicle(command, car, truck, bus, vehicleType, argument);
            }
            else if (command == "Refuel")
            {
                RefuelVehicle(car, truck, bus, vehicleType, argument);
            }
        }

        private static void GetArgs(List<string> data, out string type, out double fuelQuantity, out double fuelConsumption, out double tankCapacity)
        {
            type = data[0];
            fuelQuantity = double.Parse(data[1]);
            fuelConsumption = double.Parse(data[2]);
            tankCapacity = double.Parse(data[3]);
        }

        private void DriveVehicle(string type, IVehicle car, IVehicle truck, IVehicle bus, string vehicleType, double argument)
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
            else if (vehicleType == "Bus")
            {
                if (type == "DriveEmpty")
                {
                    bus.TurnOffAirConditioner();
                }
                else
                {
                    bus.TurnOnAirConditioner();
                }

                isDrive = bus.Drive(argument);
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

        private static void RefuelVehicle(IVehicle car, IVehicle truck, IVehicle bus, string vehicleType, double argument)
        {
            if (vehicleType == "Car")
            {
                car.Refuel(argument);
            }
            else if (vehicleType == "Truck")
            {
                truck.Refuel(argument);
            }
            else if (vehicleType == "Bus")
            {
                bus.Refuel(argument);
            }
        }

        private void Print(IVehicle car, IVehicle truck, IVehicle bus)
        {
            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
            this.writer.WriteLine(bus.ToString());
        }
    }
}