using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface IPhysicsDataService
{
    public Task AddPhysicsDataAsync(UnassignedPhysicsData unassignedPhysicsData);
    public Task AddPhysicsDataBatchAsync(IReadOnlyCollection<UnassignedPhysicsData> unassignedPhysicsData, CancellationToken cancellationToken = default);
}