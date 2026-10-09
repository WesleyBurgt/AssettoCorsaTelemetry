namespace AssettoCorsaTelemetry.Core.Entities;

public class Car
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Model { get; set; } = null!;
    public string Setup { get; set; } = null!;
}