using System.Numerics;
using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Core.Entities;

public class UnassignedPhysicsData
{
    public Guid Id { get; set; }
    
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

    public static UnassignedPhysicsData FromDto(UnassignedPhysicsDataDto dto)
    {
        AccGForces MapToAccGForces(float[] data)
        {
            if (data.Length != 3)
                throw new ArgumentException("acc g forces length is wrong");
        
            return new AccGForces
            {
                Vertical = data[0],
                Horizontal = data[1],
                Frontal =  data[2]
            };  
        }
        
        WheelData MapToWheelData(float[] data)
        {
            if (data.Length != 4)
                throw new ArgumentException("wheel data length is wrong");
        
            return new WheelData
            {
                FrontLeft = data[0],
                FrontRight = data[1],
                RearLeft = data[2],
                RearRight = data[3]
            };
        }
        
        Vector3 MapToCoordinates(float[] data)
        {
            if (data.Length != 3)
                throw new ArgumentException("coordinates length is wrong");
        
            return new Vector3
            {
                X = data[0],
                Y = data[1],
                Z =  data[2]
            };
        }

        return new UnassignedPhysicsData
        {

            Id = Guid.NewGuid(),

            Timestamp = DateTimeOffset.UtcNow,

            Identifier = dto.Identifier,

            SpeedKmh = dto.SpeedKmh,
            SpeedMph = dto.SpeedMph,
            SpeedMs = dto.SpeedMs,

            IsAbsEnabled = dto.IsAbsEnabled,
            IsAbsInAction = dto.IsAbsInAction,
            IsTcInAction = dto.IsTcInAction,
            IsTcEnabled = dto.IsTcEnabled,
            InPit = dto.InPit,
            IsEngineLimiterOn = dto.IsEngineLimiterOn,

            AccGForces = MapToAccGForces(dto.AccGForces),

            LapTime = dto.LapTime,
            LapCount = dto.LapCount,

            Throttle = dto.Throttle,
            Brake = dto.Brake,
            Clutch = dto.Clutch,
            EngineRpm = dto.EngineRpm,
            Steering = dto.Steering,

            Gear = dto.Gear,

            CgHeight = dto.CgHeight,

            WheelAngularSpeed = MapToWheelData(dto.WheelAngularSpeed),
            SlipAngle = MapToWheelData(dto.SlipAngle),
            SlipAngleContactPatch = MapToWheelData(dto.SlipAngleContactPatch),
            SlipRatio = MapToWheelData(dto.SlipRatio),
            TyreSlip = MapToWheelData(dto.TyreSlip),
            NdSlip = MapToWheelData(dto.NdSlip),
            Load = MapToWheelData(dto.Load),
            Dy = MapToWheelData(dto.Dy),
            Mz = MapToWheelData(dto.Mz),
            TyreDirtyLevel = MapToWheelData(dto.TyreDirtyLevel),
            CamberRad = MapToWheelData(dto.CamberRad),
            TyreRadius = MapToWheelData(dto.TyreRadius),
            TyreLoadedRadius = MapToWheelData(dto.TyreLoadedRadius),
            SuspensionHeight = MapToWheelData(dto.SuspensionHeight),

            CarPositionNormalized = dto.CarPositionNormalized,
            CarSlope = dto.CarSlope,

            CarCoordinates = MapToCoordinates(dto.CarCoordinates)
        };
    }
}