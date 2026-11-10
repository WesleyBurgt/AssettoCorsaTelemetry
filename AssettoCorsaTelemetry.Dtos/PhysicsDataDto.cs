namespace AssettoCorsaTelemetry.Dtos;

public class PhysicsDataDto
{
    public Guid SessionId { get; set; }
    public DateTimeOffset Timestamp { get; set; }

    public int Identifier { get; set; }
    
    public float SpeedKmh { get; set; }
    public float SpeedMph { get; set; }
    public float SpeedMs { get; set; }

    public bool IsAbsEnabled { get; set; }
    public bool IsAbsInAction { get; set; }
    public bool IsTcInAction { get; set; }
    public bool IsTcEnabled { get; set; }
    public bool InPit { get; set; }
    public bool IsEngineLimiterOn { get; set; }

    public float[] AccGForces { get; set; } = [];

    public TimeSpan LapTime { get; set; }
    public int LapCount { get; set; }

    public float Throttle { get; set; }
    public float Brake { get; set; }
    public float Clutch { get; set; }
    public float EngineRpm { get; set; }
    public float Steering { get; set; }

    public int Gear { get; set; }

    public float CgHeight { get; set; }

    public float[] WheelAngularSpeed { get; set; } = [];

    public float[] SlipAngle { get; set; } = [];

    public float[] SlipAngleContactPatch { get; set; } = [];

    public float[] SlipRatio { get; set; } = [];

    public float[] TyreSlip { get; set; } = [];

    public float[] NdSlip { get; set; } = [];

    public float[] Load { get; set; } = [];

    public float[] Dy { get; set; } = [];

    public float[] Mz { get; set; } = [];

    public float[] TyreDirtyLevel { get; set; } = [];

    public float[] CamberRad { get; set; } = [];

    public float[] TyreRadius { get; set; } = [];

    public float[] TyreLoadedRadius { get; set; } = [];

    public float[] SuspensionHeight { get; set; } = [];

    public float CarPositionNormalized { get; set; }
    public float CarSlope { get; set; }

    public float[] CarCoordinates { get; set; } = [];
}