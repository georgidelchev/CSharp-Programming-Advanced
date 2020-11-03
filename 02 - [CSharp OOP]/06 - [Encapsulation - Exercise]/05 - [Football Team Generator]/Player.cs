using Microsoft.VisualBasic.CompilerServices;
using System;

public class Player
{
    private const int MIN_STATS_VALUE = 0;
    private const int MAX_STATS_VALUE = 100;
    private const int TOTAL_STATS_COUNT = 5;

    private int dribble;
    private int endurance;
    private string name;
    private int passing;
    private int shooting;
    private int sprint;

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

    public Player(
        string name, 
        int endurance, 
        int sprint, 
        int dribble, 
        int passing, 
        int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public int Stats => CalculateAverageStats();

    private int Dribble
    {
        get
        {
            return this.dribble;
        }
        set
        {
            Validation(value, nameof(this.Dribble));

            this.dribble = value;
        }
    }

    private int Endurance
    {
        get
        {
            return this.endurance;
        }
        set
        {
            Validation(value, nameof(this.Endurance));

            this.endurance = value;
        }
    }

    private int Passing
    {
        get
        {
            return this.passing;
        }
        set
        {
            Validation(value, nameof(this.Passing));

            this.passing = value;
        }
    }

    private int Shooting
    {
        get
        {
            return this.shooting;
        }
        set
        {
            Validation(value, nameof(this.Shooting));

            this.shooting = value;
        }
    }

    private int Sprint
    {
        get
        {
            return this.sprint;
        }
        set
        {
            Validation(value, nameof(this.Sprint));

            this.sprint = value;
        }
    }

    private static void Validation(int value, string type)
    {
        if (value < MIN_STATS_VALUE ||
            value > MAX_STATS_VALUE)
        {
            throw new ArgumentException($"{type} should be between {MIN_STATS_VALUE} and {MAX_STATS_VALUE}.");
        }
    }

    private int CalculateAverageStats()
    {
        return (int)Math.Round((
            this.Dribble +
            this.Endurance +
            this.Passing +
            this.Shooting +
            this.Sprint) / (double)TOTAL_STATS_COUNT);
    }
}