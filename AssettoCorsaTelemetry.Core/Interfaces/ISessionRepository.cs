using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ISessionRepository
{
    public Task AddSessionBatchAsync(IReadOnlyCollection<Session> batch, CancellationToken cancellationToken = default);
}