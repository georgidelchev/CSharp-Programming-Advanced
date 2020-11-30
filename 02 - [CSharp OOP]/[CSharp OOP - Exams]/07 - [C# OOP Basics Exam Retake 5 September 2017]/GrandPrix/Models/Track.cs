using GrandPrix.Models.Contracts;

public class Track : ITrack
{
    public Track(int totalLaps, int length)
    {
        this.TotalLaps = totalLaps;
        this.Length = length;
        this.CurrentLap = 0;
        this.Weather = "Sunny";
    }

    public int TotalLaps { get; private set; }

    public int Length { get; private set; }

    public int CurrentLap { get; set; }

    public string Weather { get; set; }
}
