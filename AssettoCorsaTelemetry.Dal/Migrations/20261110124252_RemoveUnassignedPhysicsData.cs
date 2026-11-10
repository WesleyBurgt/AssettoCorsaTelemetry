using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssettoCorsaTelemetry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnassignedPhysicsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarId",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Id",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Timestamp",
                table: "PhysicsData");

            migrationBuilder.RenameColumn(
                name: "Data_WheelAngularSpeed_RearRight",
                table: "PhysicsData",
                newName: "WheelAngularSpeed_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_WheelAngularSpeed_RearLeft",
                table: "PhysicsData",
                newName: "WheelAngularSpeed_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_WheelAngularSpeed_FrontRight",
                table: "PhysicsData",
                newName: "WheelAngularSpeed_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_WheelAngularSpeed_FrontLeft",
                table: "PhysicsData",
                newName: "WheelAngularSpeed_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_TyreSlip_RearRight",
                table: "PhysicsData",
                newName: "TyreSlip_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_TyreSlip_RearLeft",
                table: "PhysicsData",
                newName: "TyreSlip_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_TyreSlip_FrontRight",
                table: "PhysicsData",
                newName: "TyreSlip_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_TyreSlip_FrontLeft",
                table: "PhysicsData",
                newName: "TyreSlip_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_TyreRadius_RearRight",
                table: "PhysicsData",
                newName: "TyreRadius_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_TyreRadius_RearLeft",
                table: "PhysicsData",
                newName: "TyreRadius_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_TyreRadius_FrontRight",
                table: "PhysicsData",
                newName: "TyreRadius_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_TyreRadius_FrontLeft",
                table: "PhysicsData",
                newName: "TyreRadius_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_TyreLoadedRadius_RearRight",
                table: "PhysicsData",
                newName: "TyreLoadedRadius_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_TyreLoadedRadius_RearLeft",
                table: "PhysicsData",
                newName: "TyreLoadedRadius_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_TyreLoadedRadius_FrontRight",
                table: "PhysicsData",
                newName: "TyreLoadedRadius_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_TyreLoadedRadius_FrontLeft",
                table: "PhysicsData",
                newName: "TyreLoadedRadius_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_TyreDirtyLevel_RearRight",
                table: "PhysicsData",
                newName: "TyreDirtyLevel_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_TyreDirtyLevel_RearLeft",
                table: "PhysicsData",
                newName: "TyreDirtyLevel_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_TyreDirtyLevel_FrontRight",
                table: "PhysicsData",
                newName: "TyreDirtyLevel_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_TyreDirtyLevel_FrontLeft",
                table: "PhysicsData",
                newName: "TyreDirtyLevel_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_Throttle",
                table: "PhysicsData",
                newName: "Throttle");

            migrationBuilder.RenameColumn(
                name: "Data_SuspensionHeight_RearRight",
                table: "PhysicsData",
                newName: "SuspensionHeight_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_SuspensionHeight_RearLeft",
                table: "PhysicsData",
                newName: "SuspensionHeight_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_SuspensionHeight_FrontRight",
                table: "PhysicsData",
                newName: "SuspensionHeight_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_SuspensionHeight_FrontLeft",
                table: "PhysicsData",
                newName: "SuspensionHeight_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_Steering",
                table: "PhysicsData",
                newName: "Steering");

            migrationBuilder.RenameColumn(
                name: "Data_SpeedMs",
                table: "PhysicsData",
                newName: "SpeedMs");

            migrationBuilder.RenameColumn(
                name: "Data_SpeedMph",
                table: "PhysicsData",
                newName: "SpeedMph");

            migrationBuilder.RenameColumn(
                name: "Data_SpeedKmh",
                table: "PhysicsData",
                newName: "SpeedKmh");

            migrationBuilder.RenameColumn(
                name: "Data_SlipRatio_RearRight",
                table: "PhysicsData",
                newName: "SlipRatio_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_SlipRatio_RearLeft",
                table: "PhysicsData",
                newName: "SlipRatio_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_SlipRatio_FrontRight",
                table: "PhysicsData",
                newName: "SlipRatio_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_SlipRatio_FrontLeft",
                table: "PhysicsData",
                newName: "SlipRatio_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_SlipAngle_RearRight",
                table: "PhysicsData",
                newName: "SlipAngle_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_SlipAngle_RearLeft",
                table: "PhysicsData",
                newName: "SlipAngle_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_SlipAngle_FrontRight",
                table: "PhysicsData",
                newName: "SlipAngle_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_SlipAngle_FrontLeft",
                table: "PhysicsData",
                newName: "SlipAngle_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_SlipAngleContactPatch_RearRight",
                table: "PhysicsData",
                newName: "SlipAngleContactPatch_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_SlipAngleContactPatch_RearLeft",
                table: "PhysicsData",
                newName: "SlipAngleContactPatch_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_SlipAngleContactPatch_FrontRight",
                table: "PhysicsData",
                newName: "SlipAngleContactPatch_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_SlipAngleContactPatch_FrontLeft",
                table: "PhysicsData",
                newName: "SlipAngleContactPatch_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_NdSlip_RearRight",
                table: "PhysicsData",
                newName: "NdSlip_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_NdSlip_RearLeft",
                table: "PhysicsData",
                newName: "NdSlip_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_NdSlip_FrontRight",
                table: "PhysicsData",
                newName: "NdSlip_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_NdSlip_FrontLeft",
                table: "PhysicsData",
                newName: "NdSlip_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_Mz_RearRight",
                table: "PhysicsData",
                newName: "Mz_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_Mz_RearLeft",
                table: "PhysicsData",
                newName: "Mz_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_Mz_FrontRight",
                table: "PhysicsData",
                newName: "Mz_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_Mz_FrontLeft",
                table: "PhysicsData",
                newName: "Mz_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_Load_RearRight",
                table: "PhysicsData",
                newName: "Load_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_Load_RearLeft",
                table: "PhysicsData",
                newName: "Load_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_Load_FrontRight",
                table: "PhysicsData",
                newName: "Load_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_Load_FrontLeft",
                table: "PhysicsData",
                newName: "Load_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_LapTime",
                table: "PhysicsData",
                newName: "LapTime");

            migrationBuilder.RenameColumn(
                name: "Data_LapCount",
                table: "PhysicsData",
                newName: "LapCount");

            migrationBuilder.RenameColumn(
                name: "Data_IsTcInAction",
                table: "PhysicsData",
                newName: "IsTcInAction");

            migrationBuilder.RenameColumn(
                name: "Data_IsTcEnabled",
                table: "PhysicsData",
                newName: "IsTcEnabled");

            migrationBuilder.RenameColumn(
                name: "Data_IsEngineLimiterOn",
                table: "PhysicsData",
                newName: "IsEngineLimiterOn");

            migrationBuilder.RenameColumn(
                name: "Data_IsAbsInAction",
                table: "PhysicsData",
                newName: "IsAbsInAction");

            migrationBuilder.RenameColumn(
                name: "Data_IsAbsEnabled",
                table: "PhysicsData",
                newName: "IsAbsEnabled");

            migrationBuilder.RenameColumn(
                name: "Data_InPit",
                table: "PhysicsData",
                newName: "InPit");

            migrationBuilder.RenameColumn(
                name: "Data_Identifier",
                table: "PhysicsData",
                newName: "Identifier");

            migrationBuilder.RenameColumn(
                name: "Data_Gear",
                table: "PhysicsData",
                newName: "Gear");

            migrationBuilder.RenameColumn(
                name: "Data_EngineRpm",
                table: "PhysicsData",
                newName: "EngineRpm");

            migrationBuilder.RenameColumn(
                name: "Data_Dy_RearRight",
                table: "PhysicsData",
                newName: "Dy_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_Dy_RearLeft",
                table: "PhysicsData",
                newName: "Dy_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_Dy_FrontRight",
                table: "PhysicsData",
                newName: "Dy_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_Dy_FrontLeft",
                table: "PhysicsData",
                newName: "Dy_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_Clutch",
                table: "PhysicsData",
                newName: "Clutch");

            migrationBuilder.RenameColumn(
                name: "Data_CgHeight",
                table: "PhysicsData",
                newName: "CgHeight");

            migrationBuilder.RenameColumn(
                name: "Data_CarSlope",
                table: "PhysicsData",
                newName: "CarSlope");

            migrationBuilder.RenameColumn(
                name: "Data_CarPositionNormalized",
                table: "PhysicsData",
                newName: "CarPositionNormalized");

            migrationBuilder.RenameColumn(
                name: "Data_CarCoordinates",
                table: "PhysicsData",
                newName: "CarCoordinates");

            migrationBuilder.RenameColumn(
                name: "Data_CamberRad_RearRight",
                table: "PhysicsData",
                newName: "CamberRad_RearRight");

            migrationBuilder.RenameColumn(
                name: "Data_CamberRad_RearLeft",
                table: "PhysicsData",
                newName: "CamberRad_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Data_CamberRad_FrontRight",
                table: "PhysicsData",
                newName: "CamberRad_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Data_CamberRad_FrontLeft",
                table: "PhysicsData",
                newName: "CamberRad_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Data_Brake",
                table: "PhysicsData",
                newName: "Brake");

            migrationBuilder.RenameColumn(
                name: "Data_AccGForces_Vertical",
                table: "PhysicsData",
                newName: "AccGForces_Vertical");

            migrationBuilder.RenameColumn(
                name: "Data_AccGForces_Horizontal",
                table: "PhysicsData",
                newName: "AccGForces_Horizontal");

            migrationBuilder.RenameColumn(
                name: "Data_AccGForces_Frontal",
                table: "PhysicsData",
                newName: "AccGForces_Frontal");

            migrationBuilder.RenameColumn(
                name: "TrackId",
                table: "PhysicsData",
                newName: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WheelAngularSpeed_RearRight",
                table: "PhysicsData",
                newName: "Data_WheelAngularSpeed_RearRight");

            migrationBuilder.RenameColumn(
                name: "WheelAngularSpeed_RearLeft",
                table: "PhysicsData",
                newName: "Data_WheelAngularSpeed_RearLeft");

            migrationBuilder.RenameColumn(
                name: "WheelAngularSpeed_FrontRight",
                table: "PhysicsData",
                newName: "Data_WheelAngularSpeed_FrontRight");

            migrationBuilder.RenameColumn(
                name: "WheelAngularSpeed_FrontLeft",
                table: "PhysicsData",
                newName: "Data_WheelAngularSpeed_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "TyreSlip_RearRight",
                table: "PhysicsData",
                newName: "Data_TyreSlip_RearRight");

            migrationBuilder.RenameColumn(
                name: "TyreSlip_RearLeft",
                table: "PhysicsData",
                newName: "Data_TyreSlip_RearLeft");

            migrationBuilder.RenameColumn(
                name: "TyreSlip_FrontRight",
                table: "PhysicsData",
                newName: "Data_TyreSlip_FrontRight");

            migrationBuilder.RenameColumn(
                name: "TyreSlip_FrontLeft",
                table: "PhysicsData",
                newName: "Data_TyreSlip_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "TyreRadius_RearRight",
                table: "PhysicsData",
                newName: "Data_TyreRadius_RearRight");

            migrationBuilder.RenameColumn(
                name: "TyreRadius_RearLeft",
                table: "PhysicsData",
                newName: "Data_TyreRadius_RearLeft");

            migrationBuilder.RenameColumn(
                name: "TyreRadius_FrontRight",
                table: "PhysicsData",
                newName: "Data_TyreRadius_FrontRight");

            migrationBuilder.RenameColumn(
                name: "TyreRadius_FrontLeft",
                table: "PhysicsData",
                newName: "Data_TyreRadius_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "TyreLoadedRadius_RearRight",
                table: "PhysicsData",
                newName: "Data_TyreLoadedRadius_RearRight");

            migrationBuilder.RenameColumn(
                name: "TyreLoadedRadius_RearLeft",
                table: "PhysicsData",
                newName: "Data_TyreLoadedRadius_RearLeft");

            migrationBuilder.RenameColumn(
                name: "TyreLoadedRadius_FrontRight",
                table: "PhysicsData",
                newName: "Data_TyreLoadedRadius_FrontRight");

            migrationBuilder.RenameColumn(
                name: "TyreLoadedRadius_FrontLeft",
                table: "PhysicsData",
                newName: "Data_TyreLoadedRadius_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "TyreDirtyLevel_RearRight",
                table: "PhysicsData",
                newName: "Data_TyreDirtyLevel_RearRight");

            migrationBuilder.RenameColumn(
                name: "TyreDirtyLevel_RearLeft",
                table: "PhysicsData",
                newName: "Data_TyreDirtyLevel_RearLeft");

            migrationBuilder.RenameColumn(
                name: "TyreDirtyLevel_FrontRight",
                table: "PhysicsData",
                newName: "Data_TyreDirtyLevel_FrontRight");

            migrationBuilder.RenameColumn(
                name: "TyreDirtyLevel_FrontLeft",
                table: "PhysicsData",
                newName: "Data_TyreDirtyLevel_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Throttle",
                table: "PhysicsData",
                newName: "Data_Throttle");

            migrationBuilder.RenameColumn(
                name: "SuspensionHeight_RearRight",
                table: "PhysicsData",
                newName: "Data_SuspensionHeight_RearRight");

            migrationBuilder.RenameColumn(
                name: "SuspensionHeight_RearLeft",
                table: "PhysicsData",
                newName: "Data_SuspensionHeight_RearLeft");

            migrationBuilder.RenameColumn(
                name: "SuspensionHeight_FrontRight",
                table: "PhysicsData",
                newName: "Data_SuspensionHeight_FrontRight");

            migrationBuilder.RenameColumn(
                name: "SuspensionHeight_FrontLeft",
                table: "PhysicsData",
                newName: "Data_SuspensionHeight_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Steering",
                table: "PhysicsData",
                newName: "Data_Steering");

            migrationBuilder.RenameColumn(
                name: "SpeedMs",
                table: "PhysicsData",
                newName: "Data_SpeedMs");

            migrationBuilder.RenameColumn(
                name: "SpeedMph",
                table: "PhysicsData",
                newName: "Data_SpeedMph");

            migrationBuilder.RenameColumn(
                name: "SpeedKmh",
                table: "PhysicsData",
                newName: "Data_SpeedKmh");

            migrationBuilder.RenameColumn(
                name: "SlipRatio_RearRight",
                table: "PhysicsData",
                newName: "Data_SlipRatio_RearRight");

            migrationBuilder.RenameColumn(
                name: "SlipRatio_RearLeft",
                table: "PhysicsData",
                newName: "Data_SlipRatio_RearLeft");

            migrationBuilder.RenameColumn(
                name: "SlipRatio_FrontRight",
                table: "PhysicsData",
                newName: "Data_SlipRatio_FrontRight");

            migrationBuilder.RenameColumn(
                name: "SlipRatio_FrontLeft",
                table: "PhysicsData",
                newName: "Data_SlipRatio_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "SlipAngle_RearRight",
                table: "PhysicsData",
                newName: "Data_SlipAngle_RearRight");

            migrationBuilder.RenameColumn(
                name: "SlipAngle_RearLeft",
                table: "PhysicsData",
                newName: "Data_SlipAngle_RearLeft");

            migrationBuilder.RenameColumn(
                name: "SlipAngle_FrontRight",
                table: "PhysicsData",
                newName: "Data_SlipAngle_FrontRight");

            migrationBuilder.RenameColumn(
                name: "SlipAngle_FrontLeft",
                table: "PhysicsData",
                newName: "Data_SlipAngle_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "SlipAngleContactPatch_RearRight",
                table: "PhysicsData",
                newName: "Data_SlipAngleContactPatch_RearRight");

            migrationBuilder.RenameColumn(
                name: "SlipAngleContactPatch_RearLeft",
                table: "PhysicsData",
                newName: "Data_SlipAngleContactPatch_RearLeft");

            migrationBuilder.RenameColumn(
                name: "SlipAngleContactPatch_FrontRight",
                table: "PhysicsData",
                newName: "Data_SlipAngleContactPatch_FrontRight");

            migrationBuilder.RenameColumn(
                name: "SlipAngleContactPatch_FrontLeft",
                table: "PhysicsData",
                newName: "Data_SlipAngleContactPatch_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "NdSlip_RearRight",
                table: "PhysicsData",
                newName: "Data_NdSlip_RearRight");

            migrationBuilder.RenameColumn(
                name: "NdSlip_RearLeft",
                table: "PhysicsData",
                newName: "Data_NdSlip_RearLeft");

            migrationBuilder.RenameColumn(
                name: "NdSlip_FrontRight",
                table: "PhysicsData",
                newName: "Data_NdSlip_FrontRight");

            migrationBuilder.RenameColumn(
                name: "NdSlip_FrontLeft",
                table: "PhysicsData",
                newName: "Data_NdSlip_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Mz_RearRight",
                table: "PhysicsData",
                newName: "Data_Mz_RearRight");

            migrationBuilder.RenameColumn(
                name: "Mz_RearLeft",
                table: "PhysicsData",
                newName: "Data_Mz_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Mz_FrontRight",
                table: "PhysicsData",
                newName: "Data_Mz_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Mz_FrontLeft",
                table: "PhysicsData",
                newName: "Data_Mz_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Load_RearRight",
                table: "PhysicsData",
                newName: "Data_Load_RearRight");

            migrationBuilder.RenameColumn(
                name: "Load_RearLeft",
                table: "PhysicsData",
                newName: "Data_Load_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Load_FrontRight",
                table: "PhysicsData",
                newName: "Data_Load_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Load_FrontLeft",
                table: "PhysicsData",
                newName: "Data_Load_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "LapTime",
                table: "PhysicsData",
                newName: "Data_LapTime");

            migrationBuilder.RenameColumn(
                name: "LapCount",
                table: "PhysicsData",
                newName: "Data_LapCount");

            migrationBuilder.RenameColumn(
                name: "IsTcInAction",
                table: "PhysicsData",
                newName: "Data_IsTcInAction");

            migrationBuilder.RenameColumn(
                name: "IsTcEnabled",
                table: "PhysicsData",
                newName: "Data_IsTcEnabled");

            migrationBuilder.RenameColumn(
                name: "IsEngineLimiterOn",
                table: "PhysicsData",
                newName: "Data_IsEngineLimiterOn");

            migrationBuilder.RenameColumn(
                name: "IsAbsInAction",
                table: "PhysicsData",
                newName: "Data_IsAbsInAction");

            migrationBuilder.RenameColumn(
                name: "IsAbsEnabled",
                table: "PhysicsData",
                newName: "Data_IsAbsEnabled");

            migrationBuilder.RenameColumn(
                name: "InPit",
                table: "PhysicsData",
                newName: "Data_InPit");

            migrationBuilder.RenameColumn(
                name: "Identifier",
                table: "PhysicsData",
                newName: "Data_Identifier");

            migrationBuilder.RenameColumn(
                name: "Gear",
                table: "PhysicsData",
                newName: "Data_Gear");

            migrationBuilder.RenameColumn(
                name: "EngineRpm",
                table: "PhysicsData",
                newName: "Data_EngineRpm");

            migrationBuilder.RenameColumn(
                name: "Dy_RearRight",
                table: "PhysicsData",
                newName: "Data_Dy_RearRight");

            migrationBuilder.RenameColumn(
                name: "Dy_RearLeft",
                table: "PhysicsData",
                newName: "Data_Dy_RearLeft");

            migrationBuilder.RenameColumn(
                name: "Dy_FrontRight",
                table: "PhysicsData",
                newName: "Data_Dy_FrontRight");

            migrationBuilder.RenameColumn(
                name: "Dy_FrontLeft",
                table: "PhysicsData",
                newName: "Data_Dy_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Clutch",
                table: "PhysicsData",
                newName: "Data_Clutch");

            migrationBuilder.RenameColumn(
                name: "CgHeight",
                table: "PhysicsData",
                newName: "Data_CgHeight");

            migrationBuilder.RenameColumn(
                name: "CarSlope",
                table: "PhysicsData",
                newName: "Data_CarSlope");

            migrationBuilder.RenameColumn(
                name: "CarPositionNormalized",
                table: "PhysicsData",
                newName: "Data_CarPositionNormalized");

            migrationBuilder.RenameColumn(
                name: "CarCoordinates",
                table: "PhysicsData",
                newName: "Data_CarCoordinates");

            migrationBuilder.RenameColumn(
                name: "CamberRad_RearRight",
                table: "PhysicsData",
                newName: "Data_CamberRad_RearRight");

            migrationBuilder.RenameColumn(
                name: "CamberRad_RearLeft",
                table: "PhysicsData",
                newName: "Data_CamberRad_RearLeft");

            migrationBuilder.RenameColumn(
                name: "CamberRad_FrontRight",
                table: "PhysicsData",
                newName: "Data_CamberRad_FrontRight");

            migrationBuilder.RenameColumn(
                name: "CamberRad_FrontLeft",
                table: "PhysicsData",
                newName: "Data_CamberRad_FrontLeft");

            migrationBuilder.RenameColumn(
                name: "Brake",
                table: "PhysicsData",
                newName: "Data_Brake");

            migrationBuilder.RenameColumn(
                name: "AccGForces_Vertical",
                table: "PhysicsData",
                newName: "Data_AccGForces_Vertical");

            migrationBuilder.RenameColumn(
                name: "AccGForces_Horizontal",
                table: "PhysicsData",
                newName: "Data_AccGForces_Horizontal");

            migrationBuilder.RenameColumn(
                name: "AccGForces_Frontal",
                table: "PhysicsData",
                newName: "Data_AccGForces_Frontal");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "PhysicsData",
                newName: "TrackId");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "PhysicsData",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Data_Id",
                table: "PhysicsData",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Data_Timestamp",
                table: "PhysicsData",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
