using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Engine
    {
        public void Proceed()
        {
            ICar seat = new Seat("Leon", "Grey");
            ICar tesla = new Tesla("Model 3", "Red", 2);
            //ICar audi = new Audi("RS", "Mat");

            Console.WriteLine(seat);
            Console.WriteLine(tesla);
            //Console.WriteLine(audi);
        }
    }
}
