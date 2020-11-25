namespace CounterStrike.Core
{
    using System;

    using CounterStrike.IO;
    using CounterStrike.IO.Contracts;
    using CounterStrike.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

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

                    if (input[0] == "AddGun")
                    {
                        string type = input[1];
                        string name = input[2];
                        int bulletsCount = int.Parse(input[3]);

                        result = controller.AddGun(type, name, bulletsCount);
                    }
                    else if (input[0] == "AddPlayer")
                    {
                        string type = input[1];
                        string username = input[2];
                        int health = int.Parse(input[3]);
                        int armor = int.Parse(input[4]);
                        string gunName = input[5];

                        result = controller.AddPlayer(type, username, health, armor, gunName);
                    }
                    else if (input[0] == "StartGame")
                    {
                        result = controller.StartGame();
                    }
                    else if (input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
