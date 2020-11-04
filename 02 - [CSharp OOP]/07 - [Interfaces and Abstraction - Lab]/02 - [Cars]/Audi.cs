using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Audi : Car
    {
        public Audi(string model, string color)
            : base(model, color)
        {
        }

        public override string Start()
        {
            return "Vrim-Vrim";
        }

        public override string Stop()
        {
            return "BRAAAAAAAAAAAAAAAKE";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Eta {this.Color} Audi Beast {this.Model} Brother. The best Car!");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());

            return sb.ToString().Trim();
        }
    }
}
