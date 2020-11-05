using System;
using System.Collections.Generic;
using System.Linq;
using Telephony.Core;

namespace Telephony
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
