using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces.Animals;
using WildFarm.Models;

namespace WildFarm.Interfaces
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] animalData);
    }
}
