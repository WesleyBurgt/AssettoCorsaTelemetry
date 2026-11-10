using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dal.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace AssettoCorsaTelemetry.Dal.Repositories;

public class TrackRepository(AppDbContext db) : ITrackRepository
{
    public async Task<Track> GetTrackAsync(string trackName, string trackConfiguration, CancellationToken cancellationToken = default)
    {
        Track? result = await db.Tracks.FirstOrDefaultAsync(track => track.Name == trackName && track.Configuration == trackConfiguration,  
                                                            cancellationToken);
        if (result == null)
        {
            throw new KeyNotFoundException($"track {trackName} with configuration {trackConfiguration} not found");
        }
        return result;
    }

    public async Task AddTrackAsync(Track track, CancellationToken cancellationToken = default)
    {
        db.Tracks.Add(track);
        await db.SaveChangesAsync(cancellationToken);
    }
}