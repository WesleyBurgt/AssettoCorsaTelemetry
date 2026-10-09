using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface IPhysicsDataRepository
{
    public Task AddPhysicsData(PhysicsData data);
}