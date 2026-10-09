using AssettoCorsaTelemetry.Core.Events;

namespace AssettoCorsaTelemetry.Core.Interfaces;

public interface IPhysicsDataListener
{
    event EventHandler<UnassignedPhysicsDataInfoEventArgs>? PhysicsDataInfoUpdated;
}