namespace GrandPrix.Models.Contracts
{
    public interface ITrack
    {
        int TotalLaps { get; }

        int Length { get; }

        int CurrentLap { get; }

        string Weather { get; }
    }
}