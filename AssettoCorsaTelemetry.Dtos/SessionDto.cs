namespace AssettoCorsaTelemetry.Dtos;

public class SessionDto
{
    public Guid Id { get; set; }
    public string CarName { get; set; } = null!;
    public string DriverName { get; set; } = null!;
    public string TrackName { get; set; } = null!;
    public string TrackConfiguration { get; set; } = null!;
}