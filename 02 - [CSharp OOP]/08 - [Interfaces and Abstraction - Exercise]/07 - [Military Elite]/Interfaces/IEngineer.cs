using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
