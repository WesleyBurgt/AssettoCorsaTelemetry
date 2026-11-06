namespace AssettoCorsaTelemetry.Core.Entities;

public class PhysicsData
{
    public Guid Id { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public Guid CarId { get; set; }
    public Guid TrackId { get; set; }

    public UnassignedPhysicsData Data { get; set; } = null!;
}