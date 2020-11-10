using System;

namespace ConvertToDouble
{
    public class Program
    {
        private const string INVALID_MESSAGE = "Invalid number";

        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            try
            {
                var number = Convert.ToDouble(input);
                Console.WriteLine(number);
            }
            catch (FormatException)
            {
                Console.WriteLine(INVALID_MESSAGE);
                throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine(INVALID_MESSAGE);
                throw;
            }
        }
    }
}
