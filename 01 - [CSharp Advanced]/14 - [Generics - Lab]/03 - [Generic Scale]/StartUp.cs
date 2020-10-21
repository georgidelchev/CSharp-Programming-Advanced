using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var resultInt = new EqualityScale<int>(4, 4);
            var resultString = new EqualityScale<string>("Test", "Test");
            var resultDouble = new EqualityScale<double>(2.2, 3.3);

            Console.WriteLine(resultInt.AreEqual());
            Console.WriteLine(resultString.AreEqual());
            Console.WriteLine(resultDouble.AreEqual());
        }
    }
}
