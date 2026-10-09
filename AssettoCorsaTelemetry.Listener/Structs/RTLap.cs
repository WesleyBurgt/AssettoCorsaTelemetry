using System.Runtime.InteropServices;

namespace AssettoCorsaTelemetry.Listener.Structs
{
    // ReSharper disable once InconsistentNaming
    public struct RTLap
    {
        public int CarIdentifierNumber;
        public int Lap;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string DriverName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string CarName;
        public int Time;
    };
}
