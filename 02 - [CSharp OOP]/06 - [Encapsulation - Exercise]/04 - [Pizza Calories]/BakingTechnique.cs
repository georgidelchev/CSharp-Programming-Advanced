using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class BakingTechnique
    {
        private Dictionary<string, double> pizzaBakingTechnique = new Dictionary<string, double>
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };

        public IReadOnlyDictionary<string, double> PizzaBakingTechnique => this.pizzaBakingTechnique;
    }
}
