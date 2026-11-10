using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ITrackService
{
    public Task<Track> GetTrackAsync(string trackName, string trackConfiguration, CancellationToken cancellationToken = default);
    public Task EnsureTrackExistsAsync(string trackName, string trackConfiguration, CancellationToken cancellationToken = default);
}