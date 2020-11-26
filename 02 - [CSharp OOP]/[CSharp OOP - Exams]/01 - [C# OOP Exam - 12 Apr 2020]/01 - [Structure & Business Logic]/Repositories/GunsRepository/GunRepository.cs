using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns.ToList().AsReadOnly();
        public void Add(IGun gun)
        {
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.guns.Add(gun);
        }

        public bool Remove(IGun gun)
        {
            return this.guns.Remove(gun);
        }

        public IGun FindByName(string name)
        {
            return this.guns.FirstOrDefault(g => g.Name == name);
        }
    }
}