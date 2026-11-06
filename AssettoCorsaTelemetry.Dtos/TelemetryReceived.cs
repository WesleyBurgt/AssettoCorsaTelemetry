namespace AssettoCorsaTelemetry.Dtos;

public class TelemetryReceived
{
    public Guid SessionId { get; set; }
    public Guid MessageId { get; init; }
    public UnassignedPhysicsDataDto Data { get; init; } = null!;
}