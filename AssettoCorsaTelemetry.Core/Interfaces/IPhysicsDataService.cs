using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface IPhysicsDataService
{
    public Task AddPhysicsDataAsync(UnassignedPhysicsData unassignedPhysicsData);
    public Task AddPhysicsDataBatchAsync(IReadOnlyCollection<TelemetryReceived> unassignedPhysicsData, CancellationToken cancellationToken = default);
}