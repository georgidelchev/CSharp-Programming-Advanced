using System;

namespace Christmas
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize the repository (Bag)
            Bag bag = new Bag("Blue", 20);
            //Initialize entity
            Present present = new Present("Train", 0.4, "Boy");
            //Print Present
            Console.WriteLine(present); // Present Train for a Boy

            //Add Present
            bag.Add(present);
            Console.WriteLine(bag.Count); //1
                                          //Remove Present
            bag.Remove("Doll"); //false

            Present secondPresent = new Present("Doll", 0.7, "Girl");

            //Add Present
            bag.Add(secondPresent);

            //Get heaviest present
            Present heaviestPresent = bag.GetHeaviestPresent(); // Present Doll for a Girl
                                                                //Get present
            Present searchedPresent = bag.GetPresent("Train"); // Present Train for a Boy

            Console.WriteLine(bag.Report());
            // Blue bag contains:
            // Present Train for a Boy
            // Present Doll for a Girl

        }
    }
}
