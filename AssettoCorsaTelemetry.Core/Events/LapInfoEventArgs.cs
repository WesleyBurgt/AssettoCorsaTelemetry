using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Events
{
    public class LapInfoEventArgs(Lap lap) : EventArgs
    {
        public Lap Lap { get; private set; } = lap;
    }
}