using System.Collections.Generic;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        private readonly List<ICar> cars;

        public RaceRepository()
        {
            this.cars = new List<ICar>();
        }
    }
}