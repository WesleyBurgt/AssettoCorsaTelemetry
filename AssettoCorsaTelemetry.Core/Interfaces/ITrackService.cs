using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ITrackService
{
    public Task<Track> EnsureTrackExistsAsync(string trackName, string trackConfiguration, CancellationToken cancellationToken = default);
}