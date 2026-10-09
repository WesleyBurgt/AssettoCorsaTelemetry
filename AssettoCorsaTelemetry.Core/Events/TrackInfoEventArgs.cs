using AssettoCorsaTelemetry.Core.Entities;

namespace AssettoCorsaTelemetry.Core.Events
{
    public class TrackInfoEventArgs(Track track) : EventArgs
    {
        public Track Track { get; private set; } = track;
    }
}