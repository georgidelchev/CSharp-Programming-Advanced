using System;
using System.Collections.Generic;
using System.Text;

namespace Facade.Models
{
    public class CarInfoBuilder : CarBuilderFacade
    {
        public CarInfoBuilder(Car car)
        {
            this.Car = car;
        }

        public CarInfoBuilder WithType(string type)
        {
            this.Car.Type = type;
            return this;
        }

        public CarInfoBuilder WithColor(string color)
        {
            this.Car.Color = color;
            return this;
        }

        public CarInfoBuilder WithNumberOfDoors(int numberOfDoors)
        {
            this.Car.NumberOfDoors = numberOfDoors;
            return this;
        }
    }
}
