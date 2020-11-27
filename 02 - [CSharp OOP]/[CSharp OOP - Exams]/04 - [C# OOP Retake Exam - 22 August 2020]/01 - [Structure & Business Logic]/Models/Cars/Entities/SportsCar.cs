using System;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double CUBIC_CENTIMETERS = 3000;
        private const int MINIMUM_HORSEPOWERS = 250;
        private const int MAXIMUM_HORSEPOWERS = 450;

        private int _horsepower;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower)
        {
            this.CubicCentimeters = CUBIC_CENTIMETERS;
        }

        public override int HorsePower
        {
            get => this._horsepower;
            protected set
            {
                if (value < MINIMUM_HORSEPOWERS ||
                    value > MAXIMUM_HORSEPOWERS)
                {
                    var msg = string.Format(ExceptionMessages.InvalidHorsePower, value);

                    throw new ArgumentException(msg);
                }

                this._horsepower = value;
            }
        }

        public override double CubicCentimeters { get; }
    }
}