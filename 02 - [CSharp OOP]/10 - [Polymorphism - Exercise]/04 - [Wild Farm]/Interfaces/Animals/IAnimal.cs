using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Interfaces.Animals
{
    public interface IAnimal : IProduceSound, IEatable
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        IReadOnlyCollection<string> FavouriteFood { get; }
    }
}
