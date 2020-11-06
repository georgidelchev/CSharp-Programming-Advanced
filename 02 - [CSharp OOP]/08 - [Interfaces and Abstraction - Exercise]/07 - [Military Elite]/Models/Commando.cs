using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MilitaryElite.Models
{
    class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var item in this.missions)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
