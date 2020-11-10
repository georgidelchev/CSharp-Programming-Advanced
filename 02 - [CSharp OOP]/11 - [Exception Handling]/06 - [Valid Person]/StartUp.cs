using System;

namespace ValidPerson
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var person = new Person("Stavri", "Stavrev", 10);

                Console.WriteLine(person);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ArgumentOutOfRangeException aoe)
            {
                Console.WriteLine(aoe.Message);
            }
        }
    }
}
