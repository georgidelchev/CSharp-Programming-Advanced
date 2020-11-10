using System;

namespace Fixing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var weekdays = new string[5];

            weekdays[0] = "Sunday";
            weekdays[1] = "Monday";
            weekdays[2] = "Tuesday";
            weekdays[3] = "Wednesday";
            weekdays[4] = "Thursday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i]);
                }
            }
            catch (IndexOutOfRangeException ior)
            {
                Console.WriteLine(ior.Message);
            }
        }
    }
}
