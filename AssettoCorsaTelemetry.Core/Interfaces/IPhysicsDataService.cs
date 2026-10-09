using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface IPhysicsDataService
{
    public Task AddPhysicsDataAsync(UnassignedPhysicsData unassignedPhysicsData);
}