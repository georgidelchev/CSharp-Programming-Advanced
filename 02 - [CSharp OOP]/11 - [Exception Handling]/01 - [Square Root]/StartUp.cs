using System;

namespace SquareRoot
{
    public class StartUp
    {
        private const string INVALID_MESSAGE = "Invalid number";

        public static void Main(string[] args)
        {
            try
            {
                var number = uint.Parse(Console.ReadLine());

                Console.WriteLine($"{Math.Sqrt(number):f2}");
            }
            catch (FormatException)
            {
                Console.WriteLine(INVALID_MESSAGE);
            }
            catch (ArgumentException)
            {
                Console.WriteLine(INVALID_MESSAGE);
            }
            catch (OverflowException)
            {
                Console.WriteLine(INVALID_MESSAGE);
            }
            catch (Exception)
            {
                Console.WriteLine(INVALID_MESSAGE);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
