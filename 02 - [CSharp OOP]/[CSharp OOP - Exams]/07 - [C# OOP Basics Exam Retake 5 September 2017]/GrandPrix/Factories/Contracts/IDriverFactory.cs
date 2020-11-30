using System.Collections.Generic;

public interface IDriverFactory
{
    Driver Create(List<string> commandArgs);
}
