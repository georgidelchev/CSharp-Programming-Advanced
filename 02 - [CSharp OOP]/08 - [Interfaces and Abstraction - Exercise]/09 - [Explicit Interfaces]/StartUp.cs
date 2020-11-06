using ExplicitInterfaces.Core;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Proceed();
        }
    }
}
