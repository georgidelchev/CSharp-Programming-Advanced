using System;
using System.Collections.Generic;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages.GarageModels
{
    public class Garage : IGarage
    {
        private readonly Dictionary<string, IRobot> robots;
        private const int CAPACITY = 10;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots
                    => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (CAPACITY == this.Robots.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.Robots.ContainsKey(robot.Name))
            {
                var msg = string.Format(ExceptionMessages.ExistingRobot, robot.Name);

                throw new ArgumentException(msg);
            }

            this.robots[robot.Name] = robot;
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                var msg = string.Format(ExceptionMessages.InexistingRobot,robotName);

                throw new ArgumentException(msg);
            }

            this.robots[robotName].Owner = ownerName;
            this.robots[robotName].IsBought = true;

            this.robots.Remove(robotName);
        }
    }
}