using System;
using System.Linq;
using PlayersAndMonsters.Core.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private readonly ManagerController managerController;
        public Engine()
        {
            this.managerController = new ManagerController(); ;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console
                        .ReadLine()
                        .Split()
                        .ToList();

                    var command = input[0];

                    if (command == "Exit")
                    {
                        Environment.Exit(0);
                    }
                    else if (command == "AddPlayer")
                    {
                        var playerType = input[1];
                        var playerUsername = input[2];

                        Console.WriteLine(managerController.AddPlayer(playerType, playerUsername));
                    }
                    else if (command == "AddCard")
                    {
                        var cardType = input[1];
                        var cardName = input[2];

                        Console.WriteLine(managerController.AddCard(cardType, cardName));
                    }
                    else if (command == "AddPlayerCard")
                    {
                        var username = input[1];
                        var cardName = input[2];

                        Console.WriteLine(managerController.AddPlayerCard(username, cardName));
                    }
                    else if (command == "Fight")
                    {
                        var attackUser = input[1];
                        var enemyUser = input[2];

                        Console.WriteLine(managerController.Fight(attackUser, enemyUser));
                    }
                    else if (command == "Report")
                    {
                        Console.WriteLine(managerController.Report());
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}