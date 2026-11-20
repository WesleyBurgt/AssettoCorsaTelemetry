using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ISessionService
{
    public Task AddSessionBatchAsync(IReadOnlyCollection<SessionReceived> batch, CancellationToken cancellationToken = default);
}