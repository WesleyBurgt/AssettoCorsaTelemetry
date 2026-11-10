namespace AssettoCorsaTelemetry.Core.Entities;

public class Car
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string ModelName { get; set; } = null!;
}