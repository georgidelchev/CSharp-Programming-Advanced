using System.Collections.Generic;
using System.Linq;

public class DriverFactory : IDriverFactory
{
    private readonly ITyreFactory tyreFactory;

    public DriverFactory()
    {
        this.tyreFactory = new TyreFactory();
    }

    public Driver Create(List<string> commandArgs)
    {
        var type = commandArgs[0];
        var name = commandArgs[1];
        var hp = int.Parse(commandArgs[2]);
        var fuelAmount = double.Parse(commandArgs[3]);



        Tyre tyre = tyreFactory.CreateTyre(commandArgs.Skip(4).ToList());
        Car car = new Car(hp, fuelAmount,tyre);

        Driver driver = null;
        switch (type)
        {
            case "Aggressive":
                driver = new AggressiveDriver(name,car);
                break;
            case "Endurance":
                driver = new EnduranceDriver(name,car);
                break;
        }

        return driver;
    }
}
