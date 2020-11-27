using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MINIMUM_SYMBOLS = 5;

        private readonly List<IDriver> drivers;
        private string _name;
        private int _laps;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    var msg = string.Format(ExceptionMessages.InvalidName, value, MINIMUM_SYMBOLS);

                    throw new ArgumentException(msg);
                }

                this._name = value;
            }
        }

        public int Laps
        {
            get => this._laps;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfLaps);
                }

                this._laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers
            => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                var msg = string.Format(ExceptionMessages.DriverNotParticipate, driver.Name);

                throw new ArgumentException(msg);
            }

            if (this.Drivers.Contains(driver))
            {
                var msg = string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name);

                throw new ArgumentNullException(msg);
            }

            this.drivers.Add(driver);
        }
    }
}