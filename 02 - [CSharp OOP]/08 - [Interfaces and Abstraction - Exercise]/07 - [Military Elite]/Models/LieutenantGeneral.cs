using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates => this.privates;

        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var item in this.Privates)
            {
                sb.AppendLine($"  {item}");
            }

            return sb.ToString().Trim();
        }
    }
}
