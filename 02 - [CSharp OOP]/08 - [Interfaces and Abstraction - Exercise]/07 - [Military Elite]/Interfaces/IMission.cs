using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }

        public MissionStates State { get; }

        void CompleteMission();
    }
}
