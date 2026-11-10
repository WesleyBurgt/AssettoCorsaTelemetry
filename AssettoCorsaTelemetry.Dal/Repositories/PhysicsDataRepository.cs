using AssettoCorsaTelemetry.Core;
using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dal.Postgresql;
using Microsoft.Extensions.Options;
using Npgsql;

namespace AssettoCorsaTelemetry.Dal.Repositories;

public class PhysicsDataRepository(AppDbContext db, IOptions<AppSettings> appSettings) : IPhysicsDataRepository
{
    public async Task AddPhysicsDataBatchAsync(IReadOnlyCollection<PhysicsData> batch, CancellationToken cancellationToken = default)
    {
        await using var connection = new NpgsqlConnection(appSettings.Value.ConnectionString);

        await connection.OpenAsync(cancellationToken);

        await using var writer = await connection.BeginBinaryImportAsync("""""
                                                                         COPY "PhysicsData" (
                                                                             "Timestamp",
                                                                             "Id",
                                                                             "SessionId",
                                                                             "AccGForces_Frontal",
                                                                             "AccGForces_Horizontal",
                                                                             "AccGForces_Vertical",
                                                                             "Brake",
                                                                             "CamberRad_FrontLeft",
                                                                             "CamberRad_FrontRight",
                                                                             "CamberRad_RearLeft",
                                                                             "CamberRad_RearRight",
                                                                             "CarCoordinates",
                                                                             "CarPositionNormalized",
                                                                             "CarSlope",
                                                                             "CgHeight",
                                                                             "Clutch",
                                                                             "Dy_FrontLeft",
                                                                             "Dy_FrontRight",
                                                                             "Dy_RearLeft",
                                                                             "Dy_RearRight",
                                                                             "EngineRpm",
                                                                             "Gear",
                                                                             "Identifier",
                                                                             "InPit",
                                                                             "IsAbsEnabled",
                                                                             "IsAbsInAction",
                                                                             "IsEngineLimiterOn",
                                                                             "IsTcEnabled",
                                                                             "IsTcInAction",
                                                                             "LapCount",
                                                                             "LapTime",
                                                                             "Load_FrontLeft",
                                                                             "Load_FrontRight",
                                                                             "Load_RearLeft",
                                                                             "Load_RearRight",
                                                                             "Mz_FrontLeft",
                                                                             "Mz_FrontRight",
                                                                             "Mz_RearLeft",
                                                                             "Mz_RearRight",
                                                                             "NdSlip_FrontLeft",
                                                                             "NdSlip_FrontRight",
                                                                             "NdSlip_RearLeft",
                                                                             "NdSlip_RearRight",
                                                                             "SlipAngleContactPatch_FrontLeft",
                                                                             "SlipAngleContactPatch_FrontRight",
                                                                             "SlipAngleContactPatch_RearLeft",
                                                                             "SlipAngleContactPatch_RearRight",
                                                                             "SlipAngle_FrontLeft",
                                                                             "SlipAngle_FrontRight",
                                                                             "SlipAngle_RearLeft",
                                                                             "SlipAngle_RearRight",
                                                                             "SlipRatio_FrontLeft",
                                                                             "SlipRatio_FrontRight",
                                                                             "SlipRatio_RearLeft",
                                                                             "SlipRatio_RearRight",
                                                                             "SpeedKmh",
                                                                             "SpeedMph",
                                                                             "SpeedMs",
                                                                             "Steering",
                                                                             "SuspensionHeight_FrontLeft",
                                                                             "SuspensionHeight_FrontRight",
                                                                             "SuspensionHeight_RearLeft",
                                                                             "SuspensionHeight_RearRight",
                                                                             "Throttle",
                                                                             "TyreDirtyLevel_FrontLeft",
                                                                             "TyreDirtyLevel_FrontRight",
                                                                             "TyreDirtyLevel_RearLeft",
                                                                             "TyreDirtyLevel_RearRight",
                                                                             "TyreLoadedRadius_FrontLeft",
                                                                             "TyreLoadedRadius_FrontRight",
                                                                             "TyreLoadedRadius_RearLeft",
                                                                             "TyreLoadedRadius_RearRight",
                                                                             "TyreRadius_FrontLeft",
                                                                             "TyreRadius_FrontRight",
                                                                             "TyreRadius_RearLeft",
                                                                             "TyreRadius_RearRight",
                                                                             "TyreSlip_FrontLeft",
                                                                             "TyreSlip_FrontRight",
                                                                             "TyreSlip_RearLeft",
                                                                             "TyreSlip_RearRight",
                                                                             "WheelAngularSpeed_FrontLeft",
                                                                             "WheelAngularSpeed_FrontRight",
                                                                             "WheelAngularSpeed_RearLeft",
                                                                             "WheelAngularSpeed_RearRight"
                                                                         ) FROM STDIN (FORMAT BINARY)
                                                                         """"", cancellationToken);

        foreach (var data in batch)
        {
            await writer.StartRowAsync(cancellationToken);
            
            float[] carCoordinates = [data.CarCoordinates.X, data.CarCoordinates.Y, data.CarCoordinates.Z];

            await writer.WriteAsync(data.Timestamp, cancellationToken);
            await writer.WriteAsync(data.Id, cancellationToken);
            await writer.WriteAsync(data.SessionId, cancellationToken);
            await writer.WriteAsync(data.AccGForces.Frontal, cancellationToken);
            await writer.WriteAsync(data.AccGForces.Horizontal, cancellationToken);
            await writer.WriteAsync(data.AccGForces.Vertical, cancellationToken);
            await writer.WriteAsync(data.Brake, cancellationToken);
            await writer.WriteAsync(data.CamberRad.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.CamberRad.FrontRight, cancellationToken);
            await writer.WriteAsync(data.CamberRad.RearLeft, cancellationToken);
            await writer.WriteAsync(data.CamberRad.RearRight, cancellationToken);
            await writer.WriteAsync(carCoordinates, cancellationToken);
            await writer.WriteAsync(data.CarPositionNormalized, cancellationToken);
            await writer.WriteAsync(data.CarSlope, cancellationToken);
            await writer.WriteAsync(data.CgHeight, cancellationToken);
            await writer.WriteAsync(data.Clutch, cancellationToken);
            await writer.WriteAsync(data.Dy.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Dy.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Dy.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Dy.RearRight, cancellationToken);
            await writer.WriteAsync(data.EngineRpm, cancellationToken);
            await writer.WriteAsync(data.Gear, cancellationToken);
            await writer.WriteAsync(data.Identifier, cancellationToken);
            await writer.WriteAsync(data.InPit, cancellationToken);
            await writer.WriteAsync(data.IsAbsEnabled, cancellationToken);
            await writer.WriteAsync(data.IsAbsInAction, cancellationToken);
            await writer.WriteAsync(data.IsEngineLimiterOn, cancellationToken);
            await writer.WriteAsync(data.IsTcEnabled, cancellationToken);
            await writer.WriteAsync(data.IsTcInAction, cancellationToken);
            await writer.WriteAsync(data.LapCount, cancellationToken);
            await writer.WriteAsync(data.LapTime, cancellationToken);
            await writer.WriteAsync(data.Load.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Load.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Load.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Load.RearRight, cancellationToken);
            await writer.WriteAsync(data.Mz.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Mz.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Mz.RearRight, cancellationToken);
            await writer.WriteAsync(data.Mz.RearRight, cancellationToken);
            await writer.WriteAsync(data.NdSlip.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.NdSlip.FrontRight, cancellationToken);
            await writer.WriteAsync(data.NdSlip.RearRight, cancellationToken);
            await writer.WriteAsync(data.NdSlip.RearRight, cancellationToken);
            await writer.WriteAsync(data.SlipAngleContactPatch.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.SlipAngleContactPatch.FrontRight, cancellationToken);
            await writer.WriteAsync(data.SlipAngleContactPatch.RearLeft, cancellationToken);
            await writer.WriteAsync(data.SlipAngleContactPatch.RearRight, cancellationToken);
            await writer.WriteAsync(data.SlipAngle.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.SlipAngle.FrontRight, cancellationToken);
            await writer.WriteAsync(data.SlipAngle.RearLeft, cancellationToken);
            await writer.WriteAsync(data.SlipAngle.RearRight, cancellationToken);
            await writer.WriteAsync(data.SlipRatio.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.SlipRatio.FrontRight, cancellationToken);
            await writer.WriteAsync(data.SlipRatio.RearLeft, cancellationToken);
            await writer.WriteAsync(data.SlipRatio.RearRight, cancellationToken);
            await writer.WriteAsync(data.SpeedKmh, cancellationToken);
            await writer.WriteAsync(data.SpeedMph, cancellationToken);
            await writer.WriteAsync(data.SpeedMs, cancellationToken);
            await writer.WriteAsync(data.Steering, cancellationToken);
            await writer.WriteAsync(data.SuspensionHeight.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.SuspensionHeight.FrontRight, cancellationToken);
            await writer.WriteAsync(data.SuspensionHeight.RearLeft, cancellationToken);
            await writer.WriteAsync(data.SuspensionHeight.RearRight, cancellationToken);
            await writer.WriteAsync(data.Throttle, cancellationToken);
            await writer.WriteAsync(data.TyreDirtyLevel.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.TyreDirtyLevel.FrontRight, cancellationToken);
            await writer.WriteAsync(data.TyreDirtyLevel.RearLeft, cancellationToken);
            await writer.WriteAsync(data.TyreDirtyLevel.RearRight, cancellationToken);
            await writer.WriteAsync(data.TyreLoadedRadius.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.TyreLoadedRadius.FrontRight, cancellationToken);
            await writer.WriteAsync(data.TyreLoadedRadius.RearLeft, cancellationToken);
            await writer.WriteAsync(data.TyreLoadedRadius.RearRight, cancellationToken);
            await writer.WriteAsync(data.TyreRadius.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.TyreRadius.FrontRight, cancellationToken);
            await writer.WriteAsync(data.TyreRadius.RearLeft, cancellationToken);
            await writer.WriteAsync(data.TyreRadius.RearRight, cancellationToken);
            await writer.WriteAsync(data.TyreSlip.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.TyreSlip.FrontRight, cancellationToken);
            await writer.WriteAsync(data.TyreSlip.RearLeft, cancellationToken);
            await writer.WriteAsync(data.TyreSlip.RearRight, cancellationToken);
            await writer.WriteAsync(data.WheelAngularSpeed.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.WheelAngularSpeed.FrontRight, cancellationToken);
            await writer.WriteAsync(data.WheelAngularSpeed.RearLeft, cancellationToken);
            await writer.WriteAsync(data.WheelAngularSpeed.FrontRight, cancellationToken);
        }

        await writer.CompleteAsync(cancellationToken);
    }
}