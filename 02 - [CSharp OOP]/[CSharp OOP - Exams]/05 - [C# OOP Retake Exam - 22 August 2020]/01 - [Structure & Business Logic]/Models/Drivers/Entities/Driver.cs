using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MINIMUM_SYMBOLS = 5;

        private string _name;

        public Driver(string name)
        {
            this.Name = name;
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

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
            => this.Car != null;

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddCar(ICar car)
        {
            this.Car = car ?? throw new ArgumentNullException(ExceptionMessages.CarInvalid);
        }
    }
}