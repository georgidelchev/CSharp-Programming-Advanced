using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int hapiness;
        private int energy;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;

            this.Owner = "Service";
            this.IsBought = false;
            this.IsChipped = false;
            this.IsChecked = false;
        }

        public string Name { get; }

        public int Happiness
        {
            get
            {
                return this.hapiness;
            }
            set
            {
                Validate(value, ExceptionMessages.InvalidHappiness);

                this.hapiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                Validate(value, ExceptionMessages.InvalidEnergy);

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsBought { get; set; }

        public bool IsChipped { get; set; }

        public bool IsChecked { get; set; }

        private static void Validate(int value, string msg)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(msg);
            }
        }

        public override string ToString()
        {
            return
            $" Robot type: {this.GetType().Name} - {this.Name} - " +
            $"Happiness: {this.Happiness} - " +
            $"Energy: {this.Energy}";
        }
    }
}