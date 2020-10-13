using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        public Tire(int tireYear, double tirePressure)
        {
            this.TireYear = tireYear;
            this.TirePressure = tirePressure;
        }

        public int TireYear { get; set; }

        public double TirePressure { get; set; }
    }
}
