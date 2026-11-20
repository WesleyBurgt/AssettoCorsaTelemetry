using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dal.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace AssettoCorsaTelemetry.Dal.Repositories;

public class SessionRepository(AppDbContext db) : ISessionRepository
{
    public async Task AddSessionBatchAsync(IReadOnlyCollection<Session> session, CancellationToken cancellationToken = default)
    {
        await db.Sessions.AddRangeAsync(session, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }
}