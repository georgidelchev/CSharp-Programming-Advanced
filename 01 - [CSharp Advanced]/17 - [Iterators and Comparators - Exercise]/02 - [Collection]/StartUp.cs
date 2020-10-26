using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var splittedInput = input
                    .Split()
                    .ToList();

                    var command = splittedInput[0];

                    switch (command)
                    {
                        case "Create":
                            var elements = splittedInput
                                .Skip(1)
                                .ToList();

                            listyIterator = new ListyIterator<string>(elements);
                            break;
                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;
                        case "Print":
                            listyIterator.Print();
                            break;
                        case "PrintAll":
                            listyIterator.PrintAll();
                            break;
                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
