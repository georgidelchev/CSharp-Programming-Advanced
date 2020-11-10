using System;

namespace EnterNumbers
{
    public class StartUp
    {
        private const string INVALID_MESSAGE = "Invalid number";

        public static void Main(string[] args)
        {
            try
            {
                var start = int.Parse(Console.ReadLine());
                var end = int.Parse(Console.ReadLine());

                ReadNumber(start, end);
            }
            catch (FormatException)
            {
                Console.WriteLine(INVALID_MESSAGE);
            }
            catch (OverflowException)
            {
                Console.WriteLine(INVALID_MESSAGE);
            }
        }

        private static void ReadNumber(int start, int end)
        {
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    var num = int.Parse(Console.ReadLine());

                    while (!(start <= num && num <= end))
                    {
                        Console.WriteLine($"Enter valid num {start} - {end}");

                        num = int.Parse(Console.ReadLine());
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(INVALID_MESSAGE);
                }
                catch (OverflowException)
                {
                    Console.WriteLine(INVALID_MESSAGE);
                }
            }
        }
    }
}
