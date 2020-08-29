using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            var carsQueue = new Queue<string>();

            int passedCarsCounter = 0;
            bool flag = true;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int currentGreenLightDuration = greenLightDuration;

                    while (currentGreenLightDuration > 0 && carsQueue.Any())
                    {
                        string currentCar = carsQueue.Peek();
                        int currCarLength = carsQueue.Peek().Length;

                        if (currentGreenLightDuration >= currCarLength)
                        {
                            currentGreenLightDuration -= currCarLength;
                            passedCarsCounter++;
                            carsQueue.Dequeue();
                        }
                        else
                        {
                            if (freeWindowDuration >= currCarLength - currentGreenLightDuration)
                            {
                                passedCarsCounter++;
                                carsQueue.Dequeue();
                            }
                            else
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[currentGreenLightDuration + freeWindowDuration]}.");
                                flag = false;
                                break;
                            }

                            currentGreenLightDuration = 0;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }

                if (!flag)
                {
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCarsCounter} total cars passed the crossroads.");
            }
        }
    }
}
