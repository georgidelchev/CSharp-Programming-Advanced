using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStates state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public MissionStates State { get; private set; }

        public void CompleteMission()
        {
            this.State = MissionStates.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
