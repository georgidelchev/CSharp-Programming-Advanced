using System;
using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {
        private const string offset = "  ";

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            string displacement = this.Displacement == -1 ? "n/a" : this.Displacement.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append($"{offset}{this.Model}:{Environment.NewLine}");
            sb.Append($"{offset}{offset}Power: {this.Power}{Environment.NewLine}");
            sb.Append($"{offset}{offset}Displacement: {displacement}{Environment.NewLine}");
            sb.Append($"{offset}{offset}Efficiency: {this.Efficiency}{Environment.NewLine}");

            return sb.ToString().Trim();
        }
    }

}
