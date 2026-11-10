using System.Runtime.InteropServices;

namespace AssettoCorsaTelemetry.Listener.Structs
{
    // ReSharper disable once InconsistentNaming
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public struct RTLap
    {
        public int CarIdentifierNumber;
        public int Lap;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string DriverName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string CarName;
        public int Time;
    };
}
