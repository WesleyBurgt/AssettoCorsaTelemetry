using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface ISessionService
{
    public Task AddSessionAsync(SessionDto session, CancellationToken cancellationToken = default);
}