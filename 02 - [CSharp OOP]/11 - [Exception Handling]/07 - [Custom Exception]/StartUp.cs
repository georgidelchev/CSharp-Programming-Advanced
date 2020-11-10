using System;

namespace CustomException
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var person = new Student("Gin4o", "Gin4ev", 10, "gincho@abv.bg");

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
            catch (InvalidPersonNameException ipn)
            {
                Console.WriteLine(ipn.Message);
            }
        }
    }
}
