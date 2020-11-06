using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}
