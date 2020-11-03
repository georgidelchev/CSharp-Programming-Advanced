using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Flour
    {
        private readonly Dictionary<string, double> type = new Dictionary<string, double>
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 }
        };

        public IReadOnlyDictionary<string, double> Type => this.type;
    }
}
