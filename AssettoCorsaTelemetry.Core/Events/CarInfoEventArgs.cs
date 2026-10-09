using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Events
{
    public class CarInfoEventArgs(Car car) : EventArgs
    {
        public Car Car { get; private set; } = car;
    }
}
