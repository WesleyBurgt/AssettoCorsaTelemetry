namespace AssettoCorsaTelemetry.Core.Entities;

public class Lap
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public Guid TrackId { get; set; }
    public TimeSpan Time { get; set; }
}