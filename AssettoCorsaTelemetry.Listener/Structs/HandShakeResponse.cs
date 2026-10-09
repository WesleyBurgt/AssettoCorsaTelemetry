using System.Runtime.InteropServices;

namespace AssettoCorsaTelemetry.Listener.Structs
{
    public struct HandShakeResponse
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string CarName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string DriverName;
        public int Identifier;
        public int Version;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string TrackName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string TrackConfig;
    }
}
