using System;
using System.Collections.Generic;
using System.Globalization;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Entities;
using System.Linq;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Utilities.Enumerations;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly CarRepository cars;
        private readonly DriverRepository drivers;
        private readonly RaceRepository races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers
                .GetAll()
                .Any(d => d.Name == driverName))
            {
                var msg = string.Format(ExceptionMessages.DriversExists, driverName);

                throw new ArgumentException(msg);
            }

            var driver = new Driver(driverName);

            this.drivers.Add(driver);

            var outputMessage = string.Format(OutputMessages.DriverCreated, driverName);

            return outputMessage;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars
                .GetAll()
                .Any(c => c.Model == model))
            {
                //TODO CHECK CREATE(D)
                var msg = string.Format(ExceptionMessages.CarExists, model);

                throw new ArgumentException(msg);
            }

            var car = GenerateCar(type, model, horsePower);

            this.cars.Add(car);

            var outputMessage = string.Format(OutputMessages.CarCreated, type + "Car", model);

            return outputMessage;
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races
                .GetAll()
                .Any(r => r.Name == name))
            {
                var msg = string.Format(ExceptionMessages.RaceExists, name);

                throw new InvalidOperationException(msg);
            }

            var race = new Race(name, laps);

            this.races.Add(race);

            var outputMessage = string.Format(OutputMessages.RaceCreated, name);

            return outputMessage;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (this.races
                .GetAll()
                .All(r => r.Name != raceName))
            {
                var msg = string.Format(ExceptionMessages.RaceNotFound, raceName);

                throw new InvalidOperationException(msg);
            }

            if (this.drivers
                .GetAll()
                .All(d => d.Name != driverName))
            {
                var msg = string.Format(ExceptionMessages.DriverNotFound, driverName);

                throw new InvalidOperationException(msg);
            }

            var race = this.races
                .GetAll()
                .FirstOrDefault(r => r.Name == raceName);

            var driver = this.drivers
                .GetAll()
                .FirstOrDefault(d => d.Name == driverName);

            race.AddDriver(driver);

            var outputMessage = string.Format(OutputMessages.DriverAdded, driverName, raceName);

            return outputMessage;
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (this.drivers
                .GetAll()
                .All(d => d.Name != driverName))
            {
                var msg = string.Format(ExceptionMessages.DriverNotFound, driverName);

                throw new InvalidOperationException(msg);
            }

            if (this.cars
                .GetAll()
                .All(c => c.Model != carModel))
            {
                var msg = string.Format(ExceptionMessages.CarNotFound, carModel);

                throw new InvalidOperationException(msg);
            }

            var driver = this.drivers
                .GetAll()
                .FirstOrDefault(d => d.Name == driverName);

            var car = this.cars
                .GetAll()
                .FirstOrDefault(c => c.Model == carModel);

            driver.AddCar(car);

            var outputMessage = string.Format(OutputMessages.CarAdded, driverName, carModel);

            return outputMessage;
        }

        public string StartRace(string raceName)
        {
            if (this.races
                .GetAll()
                .All(r => r.Name != raceName))
            {
                var msg = string.Format(ExceptionMessages.RaceNotFound, raceName);

                throw new InvalidOperationException(msg);
            }

            var race = this.races
                .GetAll()
                .FirstOrDefault(r => r.Name == raceName);

            if (race.Drivers.Count < 3)
            {
                var msg = string.Format(ExceptionMessages.RaceInvalid, raceName, 3);

                throw new InvalidOperationException(msg);
            }

            var winningDrivers = race
                .Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            this.races.Remove(race);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winningDrivers[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winningDrivers[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winningDrivers[2].Name, raceName));

            return sb.ToString().Trim();
        }

        private static ICar GenerateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (Enum.TryParse(type, out Cars carType))
            {
                car = carType switch
                {
                    Cars.Muscle => new MuscleCar(model, horsePower),
                    Cars.Sports => new SportsCar(model, horsePower)
                };
            }

            return car;
        }
    }
}