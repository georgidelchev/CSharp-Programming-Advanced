namespace RobotService.Core
{
    using System;

    using RobotService.IO;
    using RobotService.IO.Contracts;
    using RobotService.Core.Contracts;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    string result = string.Empty;

                    if (input[0] == "Manufacture")
                    {
                        string robotType = input[1];
                        string name = input[2];
                        int energy = int.Parse(input[3]);
                        int happiness = int.Parse(input[4]);
                        int procedureTime = int.Parse(input[5]);

                        result = controller.Manufacture(robotType, name, energy, happiness, procedureTime);
                    }
                    else if (input[0] == "Chip")
                    {
                        string name = input[1];
                        int procedureTime = int.Parse(input[2]);

                        result = controller.Chip(name, procedureTime);
                    }
                    else if (input[0] == "TechCheck")
                    {
                        string name = input[1];
                        int procedureTime = int.Parse(input[2]);

                        result = controller.TechCheck(name, procedureTime);
                    }
                    else if (input[0] == "Rest")
                    {
                        string name = input[1];
                        int procedureTime = int.Parse(input[2]);

                        result = controller.Rest(name, procedureTime);
                    }
                    else if (input[0] == "Work")
                    {
                        string name = input[1];
                        int procedureTime = int.Parse(input[2]);

                        result = controller.Work(name, procedureTime);
                    }
                    else if (input[0] == "Charge")
                    {
                        string name = input[1];
                        int procedureTime = int.Parse(input[2]);

                        result = controller.Charge(name, procedureTime);
                    }
                    else if (input[0] == "Polish")
                    {
                        string name = input[1];
                        int procedureTime = int.Parse(input[2]);

                        result = controller.Polish(name, procedureTime);
                    }
                    else if (input[0] == "Sell")
                    {
                        string robotName = input[1];
                        string ownerName = input[2];

                        result = controller.Sell(robotName, ownerName);
                    }
                    else if (input[0] == "History")
                    {
                        string procedureType = input[1];

                        result = controller.History(procedureType);
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
