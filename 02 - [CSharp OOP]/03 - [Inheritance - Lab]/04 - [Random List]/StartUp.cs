using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var myList = new RandomList();

            Console.WriteLine(myList.RandomString());
        }
    }
}
