using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color)
            : base(model, color)
        {
        }

        public override string Start()
        {
            return "Engine start";
        }

        public override string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Color} Seat {this.Model}");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());

            return sb.ToString().Trim();
        }
    }
}
