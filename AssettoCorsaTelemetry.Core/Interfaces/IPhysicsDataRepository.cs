using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface IPhysicsDataRepository
{
    public Task AddPhysicsDataBatchAsync(IReadOnlyCollection<PhysicsData> batch, CancellationToken cancellationToken = default);
}