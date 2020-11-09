using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;

namespace WildFarm.Interfaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string[] foodData);
    }
}
