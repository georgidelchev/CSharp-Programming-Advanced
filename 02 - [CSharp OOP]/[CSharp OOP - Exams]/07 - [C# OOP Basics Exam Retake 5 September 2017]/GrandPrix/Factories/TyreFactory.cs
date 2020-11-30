using System.Collections.Generic;

public class TyreFactory : ITyreFactory
{
    public Tyre CreateTyre(List<string> commandArgs)
    {
        var tyreType = commandArgs[0];
        var tyreHardness = double.Parse(commandArgs[1]);

        var grip = 0.0;
        if (tyreType == "Ultrasoft")
        {
            grip = double.Parse(commandArgs[2]);
        }

        Tyre tyre = null;
        switch (tyreType)
        {
            case "Ultrasoft":
                tyre = new UltrasoftTyre(tyreHardness, grip);
                break;
            case "Hard":
                tyre = new HardTyre(tyreHardness);
                break;
        }

        return tyre;
    }
}
