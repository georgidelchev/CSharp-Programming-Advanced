using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;

    public Team(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"A name should not be empty.");
            }

            this.name = value;
        }
    }

    private IList<Player> Players { get; set; }

    public int Rating => CalculateTeamRating();

    private int CalculateTeamRating()
    {
        if (this.Players.Any())
        {
            return (int)Math.Round(this.Players.Average(p => p.Stats));
        }
        else
        {
            return 0;
        }
    }

    public void AddPlayer(Player player)
    {
        this.Players.Add(player);
    }

    public void RemovePlayer(string player)
    {
        if (!this.Players.Any(p => p.Name == player))
        {
            throw new ArgumentException($"Player {player} is not in {this.Name} team.");
        }

        Player playerToRemove = this.Players
            .FirstOrDefault(p => p.Name == player);

        this.Players.Remove(playerToRemove);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Rating}";
    }
}