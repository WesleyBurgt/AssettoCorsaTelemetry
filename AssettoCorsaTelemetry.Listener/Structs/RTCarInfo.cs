using System.Runtime.InteropServices;

namespace AssettoCorsaTelemetry.Listener.Structs
{
    // ReSharper disable once InconsistentNaming
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    [Serializable]
    public struct RTCarInfo
    {
        public int Identifier;

        public int Size;

        public float SpeedKmh;
        public float SpeedMph;
        public float SpeedMs;

        public byte IsAbsEnabled;
        public byte IsAbsInAction;
        public byte IsTcInAction;
        public byte IsTcEnabled;
        public byte InPit;
        public byte IsEngineLimiterOn;

        private byte _flagsPadding1;
        private byte _flagsPadding2;

        public float AccGVertical;
        public float AccGHorizontal;
        public float AccGFrontal;

        public int LapTime;
        public int LastLap;
        public int BestLap;
        public int LapCount;

        public float Throttle;
        public float Brake;
        public float Clutch;
        public float EngineRPM;
        public float Steering;

        public int Gear;

        public float CgHeight;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelAngularSpeed;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SlipAngle;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SlipAngleContactPatch;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SlipRatio;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreSlip;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] NdSlip;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Load;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Dy;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Mz;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreDirtyLevel;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] CamberRad;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreRadius;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreLoadedRadius;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SuspensionHeight;

        public float CarPositionNormalized;
        public float CarSlope;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] CarCoordinates;
    }
}
