using AssettoCorsaTelemetry.Core;
using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dal.Postgresql;
using Microsoft.Extensions.Options;
using Npgsql;

namespace AssettoCorsaTelemetry.Dal.Repositories;

public class PhysicsDataRepository(AppDbContext db, IOptions<AppSettings> appSettings) : IPhysicsDataRepository
{
    public async Task AddPhysicsData(PhysicsData data, CancellationToken cancellationToken = default)
    {
        db.PhysicsDataTable.Add(data);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task AddPhysicsDataBatchAsync(IReadOnlyCollection<PhysicsData> batch, CancellationToken cancellationToken = default)
    {
        await using var connection = new NpgsqlConnection(appSettings.Value.ConnectionString);

        await connection.OpenAsync(cancellationToken);

        await using var writer = await connection.BeginBinaryImportAsync("""""
                                                                         COPY "PhysicsData" (
                                                                             "Timestamp",
                                                                             "Id",
                                                                             "CarId",
                                                                             "TrackId",
                                                                             "Data_Id",
                                                                             "Data_Timestamp",
                                                                             "Data_AccGForces_Frontal",
                                                                             "Data_AccGForces_Horizontal",
                                                                             "Data_AccGForces_Vertical",
                                                                             "Data_Brake",
                                                                             "Data_CamberRad_FrontLeft",
                                                                             "Data_CamberRad_FrontRight",
                                                                             "Data_CamberRad_RearLeft",
                                                                             "Data_CamberRad_RearRight",
                                                                             "Data_CarCoordinates",
                                                                             "Data_CarPositionNormalized",
                                                                             "Data_CarSlope",
                                                                             "Data_CgHeight",
                                                                             "Data_Clutch",
                                                                             "Data_Dy_FrontLeft",
                                                                             "Data_Dy_FrontRight",
                                                                             "Data_Dy_RearLeft",
                                                                             "Data_Dy_RearRight",
                                                                             "Data_EngineRpm",
                                                                             "Data_Gear",
                                                                             "Data_Identifier",
                                                                             "Data_InPit",
                                                                             "Data_IsAbsEnabled",
                                                                             "Data_IsAbsInAction",
                                                                             "Data_IsEngineLimiterOn",
                                                                             "Data_IsTcEnabled",
                                                                             "Data_IsTcInAction",
                                                                             "Data_LapCount",
                                                                             "Data_LapTime",
                                                                             "Data_Load_FrontLeft",
                                                                             "Data_Load_FrontRight",
                                                                             "Data_Load_RearLeft",
                                                                             "Data_Load_RearRight",
                                                                             "Data_Mz_FrontLeft",
                                                                             "Data_Mz_FrontRight",
                                                                             "Data_Mz_RearLeft",
                                                                             "Data_Mz_RearRight",
                                                                             "Data_NdSlip_FrontLeft",
                                                                             "Data_NdSlip_FrontRight",
                                                                             "Data_NdSlip_RearLeft",
                                                                             "Data_NdSlip_RearRight",
                                                                             "Data_SlipAngleContactPatch_FrontLeft",
                                                                             "Data_SlipAngleContactPatch_FrontRight",
                                                                             "Data_SlipAngleContactPatch_RearLeft",
                                                                             "Data_SlipAngleContactPatch_RearRight",
                                                                             "Data_SlipAngle_FrontLeft",
                                                                             "Data_SlipAngle_FrontRight",
                                                                             "Data_SlipAngle_RearLeft",
                                                                             "Data_SlipAngle_RearRight",
                                                                             "Data_SlipRatio_FrontLeft",
                                                                             "Data_SlipRatio_FrontRight",
                                                                             "Data_SlipRatio_RearLeft",
                                                                             "Data_SlipRatio_RearRight",
                                                                             "Data_SpeedKmh",
                                                                             "Data_SpeedMph",
                                                                             "Data_SpeedMs",
                                                                             "Data_Steering",
                                                                             "Data_SuspensionHeight_FrontLeft",
                                                                             "Data_SuspensionHeight_FrontRight",
                                                                             "Data_SuspensionHeight_RearLeft",
                                                                             "Data_SuspensionHeight_RearRight",
                                                                             "Data_Throttle",
                                                                             "Data_TyreDirtyLevel_FrontLeft",
                                                                             "Data_TyreDirtyLevel_FrontRight",
                                                                             "Data_TyreDirtyLevel_RearLeft",
                                                                             "Data_TyreDirtyLevel_RearRight",
                                                                             "Data_TyreLoadedRadius_FrontLeft",
                                                                             "Data_TyreLoadedRadius_FrontRight",
                                                                             "Data_TyreLoadedRadius_RearLeft",
                                                                             "Data_TyreLoadedRadius_RearRight",
                                                                             "Data_TyreRadius_FrontLeft",
                                                                             "Data_TyreRadius_FrontRight",
                                                                             "Data_TyreRadius_RearLeft",
                                                                             "Data_TyreRadius_RearRight",
                                                                             "Data_TyreSlip_FrontLeft",
                                                                             "Data_TyreSlip_FrontRight",
                                                                             "Data_TyreSlip_RearLeft",
                                                                             "Data_TyreSlip_RearRight",
                                                                             "Data_WheelAngularSpeed_FrontLeft",
                                                                             "Data_WheelAngularSpeed_FrontRight",
                                                                             "Data_WheelAngularSpeed_RearLeft",
                                                                             "Data_WheelAngularSpeed_RearRight"
                                                                         ) FROM STDIN (FORMAT BINARY)
                                                                         """"", cancellationToken);

        foreach (var data in batch)
        {
            await writer.StartRowAsync(cancellationToken);
            
            float[] carCoordinates = [data.Data.CarCoordinates.X, data.Data.CarCoordinates.Y, data.Data.CarCoordinates.Z];

            await writer.WriteAsync(data.Timestamp, cancellationToken);
            await writer.WriteAsync(data.Id, cancellationToken);
            await writer.WriteAsync(data.CarId, cancellationToken);
            await writer.WriteAsync(data.TrackId, cancellationToken);
            await writer.WriteAsync(data.Data.Id, cancellationToken);
            await writer.WriteAsync(data.Data.Timestamp, cancellationToken);
            await writer.WriteAsync(data.Data.AccGForces.Frontal, cancellationToken);
            await writer.WriteAsync(data.Data.AccGForces.Horizontal, cancellationToken);
            await writer.WriteAsync(data.Data.AccGForces.Vertical, cancellationToken);
            await writer.WriteAsync(data.Data.Brake, cancellationToken);
            await writer.WriteAsync(data.Data.CamberRad.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.CamberRad.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.CamberRad.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.CamberRad.RearRight, cancellationToken);
            await writer.WriteAsync(carCoordinates, cancellationToken);
            await writer.WriteAsync(data.Data.CarPositionNormalized, cancellationToken);
            await writer.WriteAsync(data.Data.CarSlope, cancellationToken);
            await writer.WriteAsync(data.Data.CgHeight, cancellationToken);
            await writer.WriteAsync(data.Data.Clutch, cancellationToken);
            await writer.WriteAsync(data.Data.Dy.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.Dy.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.Dy.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.Dy.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.EngineRpm, cancellationToken);
            await writer.WriteAsync(data.Data.Gear, cancellationToken);
            await writer.WriteAsync(data.Data.Identifier, cancellationToken);
            await writer.WriteAsync(data.Data.InPit, cancellationToken);
            await writer.WriteAsync(data.Data.IsAbsEnabled, cancellationToken);
            await writer.WriteAsync(data.Data.IsAbsInAction, cancellationToken);
            await writer.WriteAsync(data.Data.IsEngineLimiterOn, cancellationToken);
            await writer.WriteAsync(data.Data.IsTcEnabled, cancellationToken);
            await writer.WriteAsync(data.Data.IsTcInAction, cancellationToken);
            await writer.WriteAsync(data.Data.LapCount, cancellationToken);
            await writer.WriteAsync(data.Data.LapTime, cancellationToken);
            await writer.WriteAsync(data.Data.Load.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.Load.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.Load.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.Load.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.Mz.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.Mz.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.Mz.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.Mz.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.NdSlip.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.NdSlip.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.NdSlip.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.NdSlip.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.SlipAngleContactPatch.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.SlipAngleContactPatch.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.SlipAngleContactPatch.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.SlipAngleContactPatch.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.SlipAngle.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.SlipAngle.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.SlipAngle.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.SlipAngle.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.SlipRatio.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.SlipRatio.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.SlipRatio.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.SlipRatio.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.SpeedKmh, cancellationToken);
            await writer.WriteAsync(data.Data.SpeedMph, cancellationToken);
            await writer.WriteAsync(data.Data.SpeedMs, cancellationToken);
            await writer.WriteAsync(data.Data.Steering, cancellationToken);
            await writer.WriteAsync(data.Data.SuspensionHeight.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.SuspensionHeight.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.SuspensionHeight.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.SuspensionHeight.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.Throttle, cancellationToken);
            await writer.WriteAsync(data.Data.TyreDirtyLevel.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.TyreDirtyLevel.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.TyreDirtyLevel.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.TyreDirtyLevel.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.TyreLoadedRadius.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.TyreLoadedRadius.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.TyreLoadedRadius.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.TyreLoadedRadius.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.TyreRadius.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.TyreRadius.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.TyreRadius.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.TyreRadius.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.TyreSlip.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.TyreSlip.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.TyreSlip.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.TyreSlip.RearRight, cancellationToken);
            await writer.WriteAsync(data.Data.WheelAngularSpeed.FrontLeft, cancellationToken);
            await writer.WriteAsync(data.Data.WheelAngularSpeed.FrontRight, cancellationToken);
            await writer.WriteAsync(data.Data.WheelAngularSpeed.RearLeft, cancellationToken);
            await writer.WriteAsync(data.Data.WheelAngularSpeed.FrontRight, cancellationToken);
        }

        await writer.CompleteAsync(cancellationToken);
    }
}