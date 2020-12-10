namespace RobotService.Models.Garages.Contracts
{
    using System.Collections.Generic;

    using RobotService.Models.Robots.Contracts;

    public interface IGarage
    {
        IReadOnlyDictionary<string, IRobot> Robots { get; }

        void Manufacture(IRobot robot);

        void Sell(string robotName, string ownerName);
    }
}
