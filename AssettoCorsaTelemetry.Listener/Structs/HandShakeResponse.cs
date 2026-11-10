using System.Runtime.InteropServices;

namespace AssettoCorsaTelemetry.Listener.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public struct HandShakeResponse
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string CarName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string DriverName;
        public int Identifier;
        public int Version;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string TrackName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string TrackConfig;
    }
}
