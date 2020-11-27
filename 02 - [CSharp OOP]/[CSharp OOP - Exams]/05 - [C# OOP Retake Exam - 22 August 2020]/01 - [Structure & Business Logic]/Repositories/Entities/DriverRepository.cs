using System.Collections.Generic;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        private readonly List<ICar> cars;

        public DriverRepository()
        {
            this.cars = new List<ICar>();
        }
    }
}