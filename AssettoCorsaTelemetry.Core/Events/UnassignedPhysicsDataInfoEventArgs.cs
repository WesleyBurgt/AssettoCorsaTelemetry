using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Events
{
    public class UnassignedPhysicsDataInfoEventArgs(UnassignedPhysicsData physicsData) : EventArgs
    {
        public UnassignedPhysicsData PhysicsData { get; private set; } = physicsData;
    }
}