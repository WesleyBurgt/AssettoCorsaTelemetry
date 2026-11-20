namespace AssettoCorsaTelemetry.Dtos;

public class SessionReceived
{
    public Guid MessageId { get; init; }
    public SessionDto Data { get; init; } = null!;
}