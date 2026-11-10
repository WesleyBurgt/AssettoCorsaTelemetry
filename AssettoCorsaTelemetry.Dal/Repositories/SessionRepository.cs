using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dal.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace AssettoCorsaTelemetry.Dal.Repositories;

public class SessionRepository(AppDbContext db) : ISessionRepository
{
    public async Task AddSessionAsync(Session session, CancellationToken cancellationToken = default)
    {
        db.Sessions.Add(session);
        await db.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<Session> GetByIdAsync(Guid sessionId, CancellationToken cancellationToken = default)
    {
        Session? session = await db.Sessions.FirstOrDefaultAsync(s => s.Id == sessionId, cancellationToken);
        if (session == null)
        {
            throw new KeyNotFoundException("session not found");
        }
        return session;
    }
}