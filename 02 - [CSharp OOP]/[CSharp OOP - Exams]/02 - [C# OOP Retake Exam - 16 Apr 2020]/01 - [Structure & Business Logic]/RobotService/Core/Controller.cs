using System;
using System.Collections.Generic;
using RobotService.Core.Contracts;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Garages.GarageModels;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Procedures.ProceduresModels;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Enumerations;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<RobotProcedures, IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<RobotProcedures, IProcedure>();

            AddProcedures();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (!Enum.TryParse(robotType, out RobotTypes currRobotType))
            {
                var msg = string.Format(ExceptionMessages.InvalidRobotType, robotType);

                throw new ArgumentException(msg);
            }

            garage.Manufacture(CreateRobot(name, energy, happiness, procedureTime, currRobotType));

            return String.Format(OutputMessages.RobotManufactured, name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            return ExecuteProcedure(robotName, procedureTime, ExceptionMessages.InexistingRobot, OutputMessages.ChipProcedure, RobotProcedures.Chip);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            return ExecuteProcedure(robotName, procedureTime, ExceptionMessages.InexistingRobot, OutputMessages.TechCheckProcedure, RobotProcedures.TechCheck);
        }

        public string Rest(string robotName, int procedureTime)
        {
            return ExecuteProcedure(robotName, procedureTime, ExceptionMessages.InexistingRobot, OutputMessages.RestProcedure, RobotProcedures.Rest);
        }

        public string Work(string robotName, int procedureTime)
        {
            var msg = string.Format(ExceptionMessages.InexistingRobot, robotName);

            Validate(robotName, msg);

            IRobot robot = this.garage.Robots[robotName];
            IProcedure procedure = this.procedures[RobotProcedures.Work];

            procedure.DoService(robot, procedureTime);

            var outputMsg = string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);

            return outputMsg;
        }

        public string Charge(string robotName, int procedureTime)
        {
            return ExecuteProcedure(robotName, procedureTime, ExceptionMessages.InexistingRobot, OutputMessages.ChargeProcedure, RobotProcedures.Charge);
        }

        public string Polish(string robotName, int procedureTime)
        {
            return ExecuteProcedure(robotName, procedureTime, ExceptionMessages.InexistingRobot, OutputMessages.PolishProcedure, RobotProcedures.Polish);
        }

        public string Sell(string robotName, string ownerName)
        {
            var msg = string.Format(ExceptionMessages.InexistingRobot, robotName);

            Validate(robotName, msg);

            IRobot robot = this.garage.Robots[robotName];

            this.garage.Sell(robot.Name, robot.Owner);

            var outputMsg = "";

            if (robot.IsChipped)
            {
                outputMsg = string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                outputMsg = string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }

            return outputMsg;
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out RobotProcedures currentProcedure);

            IProcedure procedure = this.procedures[currentProcedure];

            return procedure.History().Trim();
        }

        private static IRobot CreateRobot(string name, int energy, int happiness, int procedureTime, RobotTypes currRobotType)
        {
            IRobot robot = null;

            switch (currRobotType)
            {
                case RobotTypes.HouseholdRobot:
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotTypes.WalkerRobot:
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotTypes.PetRobot:
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
            }

            return robot;
        }

        private void Validate(string robotName, string msg)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(msg);
            }
        }

        private void AddProcedures()
        {
            this.procedures.Add(RobotProcedures.Chip, new Chip());
            this.procedures.Add(RobotProcedures.Charge, new Charge());
            this.procedures.Add(RobotProcedures.Rest, new Rest());
            this.procedures.Add(RobotProcedures.Polish, new Polish());
            this.procedures.Add(RobotProcedures.Work, new Work());
            this.procedures.Add(RobotProcedures.TechCheck, new TechCheck());
        }

        private string ExecuteProcedure(string robotName, int procedureTime, string message, string outputMessage, RobotProcedures robotProcedure)
        {
            var msg = string.Format(message, robotName);

            Validate(robotName, msg);

            IRobot robot = this.garage.Robots[robotName];
            IProcedure procedure = this.procedures[robotProcedure];

            procedure.DoService(robot, procedureTime);

            var outputMsg = string.Format(outputMessage, robotName);

            return outputMsg;
        }
    }
}