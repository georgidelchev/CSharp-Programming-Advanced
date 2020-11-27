using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MINIMUM_SYMBOLS = 4;

        private string _model;

        protected Car(string model, int horsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Model
        {
            get => this._model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    value.Length < MINIMUM_SYMBOLS)
                {
                    var msg = string.Format(ExceptionMessages.InvalidModel, value, MINIMUM_SYMBOLS);

                    throw new ArgumentException(msg);
                }

                this._model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }

        public abstract double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            var pointsFromRace = (this.CubicCentimeters / this.HorsePower) * laps;

            return pointsFromRace;
        }
    }
}