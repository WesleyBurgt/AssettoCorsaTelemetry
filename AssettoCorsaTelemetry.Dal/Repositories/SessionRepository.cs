using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dal.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace AssettoCorsaTelemetry.Dal.Repositories;

public class SessionRepository(AppDbContext db) : ISessionRepository
{
    public async Task<Session> GetByIdAsync(Guid sessionId, CancellationToken cancellationToken = default)
    {
        Session? session = await db.Sessions.FirstOrDefaultAsync(s => s.Id == sessionId, cancellationToken: cancellationToken);
        if (session == null)
        {
            return new Session
            {
                Id = sessionId,
                CarId = Guid.Empty,
                TrackId = Guid.Empty,
                UserId = Guid.Empty,
            };
            throw new KeyNotFoundException("session not found");
        }
        return session;
    }
}