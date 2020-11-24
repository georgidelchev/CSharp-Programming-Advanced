using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures.ProceduresModels
{
    public abstract class Procedure : IProcedure
    {
        protected readonly IList<IRobot> robotsList;

        protected Procedure()
        {
            this.robotsList = new List<IRobot>();
        }

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);

            foreach (var item in this.robotsList)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;

            this.robotsList.Add(robot);
        }
    }
}