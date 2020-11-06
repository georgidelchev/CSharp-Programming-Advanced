using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
