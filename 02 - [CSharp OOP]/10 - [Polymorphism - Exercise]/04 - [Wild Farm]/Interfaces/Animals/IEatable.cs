using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;

namespace WildFarm.Interfaces.Animals
{
    public interface IEatable
    {
        void Eat(IFood food);
    }
}
