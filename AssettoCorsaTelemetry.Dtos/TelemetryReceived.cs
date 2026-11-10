namespace AssettoCorsaTelemetry.Dtos;

public class TelemetryReceived
{
    public Guid MessageId { get; init; }
    public PhysicsDataDto Data { get; init; } = null!;
}