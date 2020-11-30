using System.Collections.Generic;

public interface ITyreFactory
{
    Tyre CreateTyre(List<string> commandArgs);
}
