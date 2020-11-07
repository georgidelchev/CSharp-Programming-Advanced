using Operations.Core;
using System;

namespace Operations
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
