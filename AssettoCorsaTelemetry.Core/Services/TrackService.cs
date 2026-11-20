using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;

namespace AssettoCorsaTelemetry.Core.Services;

public class TrackService(ITrackRepository repository) : ITrackService
{
    public async Task<Track> EnsureTrackExistsAsync(string trackName, string trackConfiguration, CancellationToken cancellationToken = default)
    {
        try
        {
            Track track = await repository.GetTrackAsync(trackName, trackConfiguration, cancellationToken);
            return track;
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
            return track;
        }
    }
}