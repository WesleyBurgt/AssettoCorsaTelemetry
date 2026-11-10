using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;

namespace AssettoCorsaTelemetry.Core.Services;

public class TrackService(ITrackRepository repository) : ITrackService
{
    public async Task<Track> GetTrackAsync(string trackName, string trackConfig, CancellationToken cancellationToken = default)
    {
        Track track = await repository.GetTrackAsync(trackName, trackConfig, cancellationToken);
        return track;
    }

    public async Task EnsureTrackExistsAsync(string trackName, string trackConfiguration, CancellationToken cancellationToken = default)
    {
        try
        {
            await GetTrackAsync(trackName, trackConfiguration, cancellationToken);
        }
        catch (KeyNotFoundException) //adds if it does not exist
        {
            Track track = new Track
            {
                Id = Guid.NewGuid(),
                Name = trackName,
                Configuration = trackConfiguration,
            };
            await repository.AddTrackAsync(track, cancellationToken);
        }
    }
}