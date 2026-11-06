namespace AssettoCorsaTelemetry.Core.Entities;

public class Session
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public Guid TrackId { get; set; }
    public Guid UserId { get; set; }
}