using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface IPhysicsDataService
{
    public Task AddPhysicsDataBatchAsync(IReadOnlyCollection<TelemetryReceived> physicsData, CancellationToken cancellationToken = default);
}