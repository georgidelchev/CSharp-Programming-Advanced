namespace CounterStrike.IO
{
    using System;

    using CounterStrike.IO.Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}