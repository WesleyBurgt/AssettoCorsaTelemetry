using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ITrackRepository
{
    public Task<Track> GetTrackAsync(string trackName, string trackConfiguration, CancellationToken cancellationToken = default);
    public Task AddTrackAsync(Track track, CancellationToken cancellationToken = default);
}