using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower : IController
{
    private readonly Dictionary<string, Driver> drivers;
    private readonly Dictionary<Driver, string> disqDrivers;

    private Track track;
    private readonly IDriverFactory driverFactory;
    private readonly ITyreFactory tyreFactory;

    public bool hasWinner;
    public Driver winner;

    public RaceTower()
    {
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();

        this.drivers = new Dictionary<string, Driver>();
        this.disqDrivers = new Dictionary<Driver, string>();

        this.hasWinner = false;
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driver = this.driverFactory
                .Create(commandArgs);

            this.drivers.Add(driver.Name, driver);
        }
        catch (Exception)
        {
            // ignored
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driver = this.drivers[commandArgs[1]];

        driver.IncreaseTime(20);

        if (reasonToBox == "ChangeTyres")
        {
            var tyre = this.tyreFactory.CreateTyre(commandArgs.Skip(2).ToList());

            driver.Car.ChangeTyre(tyre);
        }
        else if (reasonToBox == "Refuel")
        {
            double fuel = double.Parse(commandArgs[2]);

            driver.Car.Refuel(fuel);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int lap = int.Parse(commandArgs[0]);

        if (this.track.TotalLaps - lap < 0)
        {
            return $"There is no time! On lap {this.track.CurrentLap}.";
        }
        else
        {
            var sb = new StringBuilder();

            for (int i = 0; i < lap; i++)
            {
                foreach (var driver in this.drivers.Values)
                {
                    driver.IncreaseTime(60 / (this.track.Length / driver.Speed));
                }

                foreach (var driver in this.drivers.Values)
                {
                    try
                    {
                        driver.Car.ReduceFuel(this.track.Length);
                        driver.Car.Tyre.DegradationReduce();
                    }
                    catch (ArgumentException ae)
                    {
                        this.disqDrivers.Add(driver, ae.Message);
                    }
                }

                foreach (var disqDriver in this.disqDrivers.Keys)
                {
                    if (this.drivers.ContainsKey(disqDriver.Name))
                    {
                        this.drivers.Remove(disqDriver.Name);
                    }
                }

                this.track.CurrentLap++;

                var standings = this.drivers
                    .Values
                    .OrderByDescending(d => d.TotalTime)
                    .ToList();

                for (int j = 0; j < standings.Count - 1; j++)
                {
                    var frondDriver = standings[i];
                    var behindDriver = standings[i + 1];

                    var gap = Math.Abs(frondDriver.TotalTime - behindDriver.TotalTime);

                    int interval = 2;

                    bool isCrashed = false;

                    if (frondDriver.GetType().Name == "AggressiveDriver" &&
                        frondDriver.Car.Tyre.GetType().Name == "UltrasoftTyre")
                    {
                        interval = 3;
                        if (this.track.Weather == "Foggy")
                        {
                            isCrashed = true;
                        }
                    }

                    if (frondDriver.GetType().Name == "EnduranceDriver" &&
                        frondDriver.Car.Tyre.GetType().Name == "HardTyre")
                    {
                        interval = 3;
                        if (this.track.Weather == "Rainy")
                        {
                            isCrashed = true;
                        }
                    }

                    if (gap <= interval)
                    {
                        if (isCrashed)
                        {
                            this.disqDrivers.Add(frondDriver, "Crashed");
                            this.drivers.Remove(frondDriver.Name);

                            continue;
                        }

                        frondDriver.TotalTime -= interval;
                        behindDriver.TotalTime += interval;

                        sb.AppendLine(
                            $"{frondDriver.Name} has overtaken {behindDriver.Name} on lap {this.track.CurrentLap}.");
                    }
                }

                if (this.track.CurrentLap == this.track.TotalLaps)
                {
                    this.hasWinner = true;

                    this.winner = this.drivers
                        .Values
                        .OrderBy(d => d.TotalTime)
                        .FirstOrDefault();
                }
            }

            return sb.ToString().Trim();
        }
    }

    public string GetLeaderboard()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Lap {this.track.CurrentLap}/{this.track.TotalLaps}");

        int position = 1;

        foreach (var driver in this.drivers
            .Values
            .OrderBy(d => d.TotalTime))
        {
            sb.AppendLine($"{position} {driver.Name} {driver.TotalTime:F3}");
            position++;
        }

        foreach (KeyValuePair<Driver, string> disqDriver in this.disqDrivers.Reverse())
        {
            sb.AppendLine($"{position} {disqDriver.Key.Name} {disqDriver.Value}");
            position++;
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.track.Weather = commandArgs[0];
    }
}