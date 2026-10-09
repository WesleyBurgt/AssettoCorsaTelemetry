namespace AssettoCorsaTelemetry.Core.Entities;

public class WheelData
{
    public Guid Id { get; set; }
    public float FrontLeft { get; set; }
    public float FrontRight { get; set; }
    public float RearLeft { get; set; }
    public float RearRight { get; set; }
}