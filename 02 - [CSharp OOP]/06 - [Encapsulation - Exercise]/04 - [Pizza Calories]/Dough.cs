using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double CALORIES_PER_GRAM = 2;
        private const double MINIMUM_DOUGH_WEIGHT = 1;
        private const double MAXIMUM_DOUGH_WEIGHT = 200;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        private Flour defaultFlourTypes;
        private BakingTechnique defaultBakingTechniques;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.defaultFlourTypes = new Flour();
            this.defaultBakingTechniques = new BakingTechnique();

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                bool isFlourTypeIsValid = this.DefaultFlourTypes.Type.ContainsKey(value.ToLower());

                if (!isFlourTypeIsValid)
                {
                    ExceptionMessage();
                }

                this.flourType = value;
            }
        }


        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                bool isBakingTechniqueValid = this.DefaultBakingTechniques.PizzaBakingTechnique.ContainsKey(value.ToLower());

                if (!isBakingTechniqueValid)
                {
                    ExceptionMessage();
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < MINIMUM_DOUGH_WEIGHT || value > MAXIMUM_DOUGH_WEIGHT)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MINIMUM_DOUGH_WEIGHT}..{MAXIMUM_DOUGH_WEIGHT}].");
                }

                this.weight = value;
            }
        }

        public Flour DefaultFlourTypes
        {
            get { return this.defaultFlourTypes; }
            private set { this.defaultFlourTypes = value; }
        }

        public BakingTechnique DefaultBakingTechniques
        {
            get { return this.defaultBakingTechniques; }
            private set { this.defaultBakingTechniques = value; }
        }

        private static void ExceptionMessage()
                => throw new ArgumentException("Invalid type of dough.");

        public double TotalCalories()
        {
            double flourCalories = this.DefaultFlourTypes.Type[this.FlourType];
            double bakingTechniqueCalories = this.DefaultBakingTechniques.PizzaBakingTechnique[this.BakingTechnique];
            double doughCalories = (this.Weight * CALORIES_PER_GRAM);

            double totalCalories = doughCalories * flourCalories * bakingTechniqueCalories;

            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.TotalCalories():f2}";
        }
    }
}
