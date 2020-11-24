using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.ProceduresModels
{
    public class Rest : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= 3;
            robot.Energy += 10;
        }
    }
}