using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        public void AddMission(IMission mission);
    }
}
