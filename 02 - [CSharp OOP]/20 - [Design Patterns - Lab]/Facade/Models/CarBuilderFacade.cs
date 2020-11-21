using System;
using System.Collections.Generic;
using System.Text;

namespace Facade.Models
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            this.Car = new Car();
        }

        public Car Build() => this.Car;

        public CarInfoBuilder Info => new CarInfoBuilder(this.Car);

        public CarAddressBuilder Built => new CarAddressBuilder(this.Car);
    }
}
