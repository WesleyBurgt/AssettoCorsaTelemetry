namespace AssettoCorsaTelemetry.Core.Entities;

public class Track
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Configuration { get; set; } = null!;
}