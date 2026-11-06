using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ISessionRepository
{
    public Task<Session> GetByIdAsync(Guid sessionId, CancellationToken cancellationToken = default);
}