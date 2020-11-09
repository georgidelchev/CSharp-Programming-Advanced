using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces.IO;

namespace WildFarm.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
