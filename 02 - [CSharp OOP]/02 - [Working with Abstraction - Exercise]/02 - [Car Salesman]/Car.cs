using System;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {
        private const string offset = "  ";

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            string weight = this.Weight == -1 ? "n/a" : this.Weight.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Model}:{Environment.NewLine}");
            sb.Append($"{offset}{this.Engine}{Environment.NewLine}");
            sb.Append($"{offset}Weight: {weight}{Environment.NewLine}");
            sb.Append($"{offset}Color: {this.Color}");

            return sb.ToString().Trim();
        }
    }

}
