using System.Numerics;

namespace AssettoCorsaTelemetry.Core.Entities;

public class UnassignedPhysicsData
{
    public Guid Id { get; set; }
    
    public DateTimeOffset Timestamp { get; set; }

    public int Identifier { get; set; }

    public int Size { get; set; }

    public float SpeedKmh { get; set; }
    public float SpeedMph { get; set; }
    public float SpeedMs { get; set; }

    public bool IsAbsEnabled { get; set; }
    public bool IsAbsInAction { get; set; }
    public bool IsTcInAction { get; set; }
    public bool IsTcEnabled { get; set; }
    public bool InPit { get; set; }
    public bool IsEngineLimiterOn { get; set; }

    public AccGForces AccGForces { get; set; } = null!;

    public TimeSpan LapTime { get; set; }
    public int LapCount { get; set; }

    public float Throttle { get; set; }
    public float Brake { get; set; }
    public float Clutch { get; set; }
    public float EngineRpm { get; set; }
    public float Steering { get; set; }

    public int Gear { get; set; }

    public float CgHeight { get; set; }

    public WheelData WheelAngularSpeed { get; set; } = null!;

    public WheelData SlipAngle { get; set; } = null!;

    public WheelData SlipAngleContactPatch { get; set; } = null!;

    public WheelData SlipRatio { get; set; } = null!;

    public WheelData TyreSlip { get; set; } = null!;

    public WheelData NdSlip { get; set; } = null!;

    public WheelData Load { get; set; } = null!;

    public WheelData Dy { get; set; } = null!;

    public WheelData Mz { get; set; } = null!;

    public WheelData TyreDirtyLevel { get; set; } = null!;

    public WheelData CamberRad { get; set; } = null!;

    public WheelData TyreRadius { get; set; } = null!;

    public WheelData TyreLoadedRadius { get; set; } = null!;

    public WheelData SuspensionHeight { get; set; } = null!;

    public float CarPositionNormalized { get; set; }
    public float CarSlope { get; set; }

    public Vector3 CarCoordinates { get; set; }
}