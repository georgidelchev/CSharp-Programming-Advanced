using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures.ProceduresModels
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= 5;

            if (robot.IsChipped)
            {
                string msg = string.Format(ExceptionMessages.AlreadyChipped, robot.Name);

                throw new ArgumentException(msg);
            }

            robot.IsChipped = true;
        }
    }
}