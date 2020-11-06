using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier:IPrivate
    {
        Corps Corps { get; }
    }
}
