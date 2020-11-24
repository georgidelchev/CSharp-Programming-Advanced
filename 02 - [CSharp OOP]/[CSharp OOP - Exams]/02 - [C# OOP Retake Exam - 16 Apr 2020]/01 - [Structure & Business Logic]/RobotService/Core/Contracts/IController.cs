namespace RobotService.Core.Contracts
{
    public interface IController
    {
        string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime);

        string Chip(string robotName, int procedureTime);

        string TechCheck(string robotName, int procedureTime);

        string Rest(string robotName, int procedureTime);

        string Work(string robotName, int procedureTime);

        string Charge(string robotName, int procedureTime);

        string Polish(string robotName, int procedureTime);

        string Sell(string robotName, string ownerName);

        string History(string procedureType);
    }
}
