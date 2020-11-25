namespace CounterStrike.Models.Maps.Contracts
{
    using CounterStrike.Models.Players.Contracts;
    using System.Collections.Generic;

    public interface IMap
    {
        string Start(ICollection<IPlayer> players);
    }
}
