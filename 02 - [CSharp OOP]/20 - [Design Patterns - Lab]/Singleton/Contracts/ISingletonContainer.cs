using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public interface ISingletonContainer
    {
        int GetPopulation(string name);
    }
}
