namespace RobotService.Models.Robots.Contracts
{
    public interface IRobot
    {
        string Name { get; }

        int Happiness { get; set; }

        int Energy { get; set; }

        int ProcedureTime { get; set; }

        string Owner { get; set; }

        bool IsBought { get; set; }

        bool IsChipped { get; set; }

        bool IsChecked { get; set; }
    }
}
