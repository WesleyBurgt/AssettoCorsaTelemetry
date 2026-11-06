using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface IPhysicsDataRepository
{
    public Task AddPhysicsData(PhysicsData data, CancellationToken cancellationToken = default);
    public Task AddPhysicsDataBatchAsync(IReadOnlyCollection<PhysicsData> batch, CancellationToken cancellationToken = default);

}