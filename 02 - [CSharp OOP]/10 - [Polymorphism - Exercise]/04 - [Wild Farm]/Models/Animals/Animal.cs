using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Interfaces;
using WildFarm.Interfaces.Animals;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal, IEatable
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightIncrease { get; }

        public abstract IReadOnlyCollection<string> FavouriteFood { get; }

        public void Eat(IFood food)
        {
            MyException.CheckFood(this.GetType().Name, food.GetType().Name, this.FavouriteFood);

            this.Weight += this.WeightIncrease * food.Quantity;

            this.FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name}";
        }
    }
}
