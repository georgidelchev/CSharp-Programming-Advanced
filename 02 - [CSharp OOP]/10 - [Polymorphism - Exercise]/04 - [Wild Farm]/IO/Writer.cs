using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces.IO;

namespace WildFarm.IO
{
    public class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
