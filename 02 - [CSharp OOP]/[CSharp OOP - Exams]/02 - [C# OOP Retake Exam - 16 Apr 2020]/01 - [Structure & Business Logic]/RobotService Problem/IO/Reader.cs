namespace RobotService.IO
{
    using System;

    using RobotService.IO.Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}