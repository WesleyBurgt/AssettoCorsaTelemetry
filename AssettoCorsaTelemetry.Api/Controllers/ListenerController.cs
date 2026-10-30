using System.Numerics;
using AssettoCorsaTelemetry.Dtos;
using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssettoCorsaTelemetry.Api.Controllers;

[ApiController]
[Route("listener")]
public class ListenerController(IPhysicsDataService physicsDataService) : ControllerBase
{
    [HttpPost("addphysicsdata")]
    public async Task<IActionResult> AddPhysicsData([FromBody] UnassignedPhysicsDataDto dto)
    {
        try
        {
            UnassignedPhysicsData data = MapToUnassignedPhysicsData(dto);
            await physicsDataService.AddPhysicsDataAsync(data);
            return Ok();
        }
        catch (BadHttpRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    private UnassignedPhysicsData MapToUnassignedPhysicsData(UnassignedPhysicsDataDto dto)
    {
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

    private WheelData MapToWheelData(float[] data)
    {
        if (data.Length != 4)
            throw new BadHttpRequestException("wheel data length is wrong");
        
        return new WheelData
        {
            Id = Guid.NewGuid(),
            FrontLeft = data[0],
            FrontRight = data[1],
            RearLeft = data[2],
            RearRight = data[3]
        };
    }

    private AccGForces MapToAccGForces(float[] data)
    {
        if (data.Length != 3)
            throw new BadHttpRequestException("acc g forces length is wrong");
        
        return new AccGForces
        {
            Id = Guid.NewGuid(),
            Vertical = data[0],
            Horizontal = data[1],
            Frontal =  data[2]
        };
    }

    private Vector3 MapToCoordinates(float[] data)
    {
        if (data.Length != 3)
            throw new BadHttpRequestException("acc g forces length is wrong");
        
        return new Vector3
        {
            X = data[0],
            Y = data[1],
            Z =  data[2]
        };
    }
}