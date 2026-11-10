using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssettoCorsaTelemetry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FlattenDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhysicsDataTable_UnassignedPhysicsData_DataTimestamp_DataId",
                table: "PhysicsDataTable");

            migrationBuilder.DropTable(
                name: "UnassignedPhysicsData");

            migrationBuilder.DropTable(
                name: "AccGForces");

            migrationBuilder.DropTable(
                name: "WheelData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhysicsDataTable",
                table: "PhysicsDataTable");

            migrationBuilder.DropIndex(
                name: "IX_PhysicsDataTable_DataTimestamp_DataId",
                table: "PhysicsDataTable");

            migrationBuilder.RenameTable(
                name: "PhysicsDataTable",
                newName: "PhysicsData");

            migrationBuilder.RenameColumn(
                name: "DataTimestamp",
                table: "PhysicsData",
                newName: "Data_Timestamp");

            migrationBuilder.RenameColumn(
                name: "DataId",
                table: "PhysicsData",
                newName: "Data_Id");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Timestamp",
                table: "PhysicsData",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<float>(
                name: "Data_AccGForces_Frontal",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_AccGForces_Horizontal",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_AccGForces_Vertical",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Brake",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_CamberRad_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_CamberRad_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_CamberRad_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_CamberRad_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<List<float>>(
                name: "Data_CarCoordinates",
                table: "PhysicsData",
                type: "real[]",
                nullable: false);

            migrationBuilder.AddColumn<float>(
                name: "Data_CarPositionNormalized",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_CarSlope",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_CgHeight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Clutch",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Dy_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Dy_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Dy_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Dy_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_EngineRpm",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Data_Gear",
                table: "PhysicsData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data_Identifier",
                table: "PhysicsData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Data_InPit",
                table: "PhysicsData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Data_IsAbsEnabled",
                table: "PhysicsData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Data_IsAbsInAction",
                table: "PhysicsData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Data_IsEngineLimiterOn",
                table: "PhysicsData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Data_IsTcEnabled",
                table: "PhysicsData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Data_IsTcInAction",
                table: "PhysicsData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Data_LapCount",
                table: "PhysicsData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Data_LapTime",
                table: "PhysicsData",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<float>(
                name: "Data_Load_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Load_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Load_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Load_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Mz_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Mz_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Mz_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Mz_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_NdSlip_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_NdSlip_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_NdSlip_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_NdSlip_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipAngleContactPatch_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipAngleContactPatch_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipAngleContactPatch_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipAngleContactPatch_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipAngle_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipAngle_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipAngle_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipAngle_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipRatio_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipRatio_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipRatio_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SlipRatio_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SpeedKmh",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SpeedMph",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SpeedMs",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Steering",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SuspensionHeight_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SuspensionHeight_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SuspensionHeight_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_SuspensionHeight_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_Throttle",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreDirtyLevel_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreDirtyLevel_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreDirtyLevel_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreDirtyLevel_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreLoadedRadius_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreLoadedRadius_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreLoadedRadius_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreLoadedRadius_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreRadius_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreRadius_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreRadius_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreRadius_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreSlip_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreSlip_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreSlip_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_TyreSlip_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_WheelAngularSpeed_FrontLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_WheelAngularSpeed_FrontRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_WheelAngularSpeed_RearLeft",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Data_WheelAngularSpeed_RearRight",
                table: "PhysicsData",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhysicsData",
                table: "PhysicsData",
                columns: new[] { "Timestamp", "Id" });
            
            migrationBuilder.Sql("""
                                     SELECT create_hypertable(
                                         'public."PhysicsData"',
                                         by_range('Timestamp', INTERVAL '1 day'),
                                         if_not_exists => TRUE
                                     );
                                 """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PhysicsData",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_AccGForces_Frontal",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_AccGForces_Horizontal",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_AccGForces_Vertical",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Brake",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_CamberRad_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_CamberRad_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_CamberRad_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_CamberRad_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_CarCoordinates",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_CarPositionNormalized",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_CarSlope",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_CgHeight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Clutch",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Dy_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Dy_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Dy_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Dy_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_EngineRpm",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Gear",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Identifier",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_InPit",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_IsAbsEnabled",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_IsAbsInAction",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_IsEngineLimiterOn",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_IsTcEnabled",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_IsTcInAction",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_LapCount",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_LapTime",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Load_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Load_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Load_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Load_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Mz_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Mz_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Mz_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Mz_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_NdSlip_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_NdSlip_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_NdSlip_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_NdSlip_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipAngleContactPatch_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipAngleContactPatch_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipAngleContactPatch_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipAngleContactPatch_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipAngle_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipAngle_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipAngle_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipAngle_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipRatio_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipRatio_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipRatio_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SlipRatio_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SpeedKmh",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SpeedMph",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SpeedMs",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Steering",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SuspensionHeight_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SuspensionHeight_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SuspensionHeight_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_SuspensionHeight_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_Throttle",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreDirtyLevel_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreDirtyLevel_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreDirtyLevel_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreDirtyLevel_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreLoadedRadius_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreLoadedRadius_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreLoadedRadius_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreLoadedRadius_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreRadius_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreRadius_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreRadius_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreRadius_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreSlip_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreSlip_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreSlip_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_TyreSlip_RearRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_WheelAngularSpeed_FrontLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_WheelAngularSpeed_FrontRight",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_WheelAngularSpeed_RearLeft",
                table: "PhysicsData");

            migrationBuilder.DropColumn(
                name: "Data_WheelAngularSpeed_RearRight",
                table: "PhysicsData");

            migrationBuilder.RenameTable(
                name: "PhysicsData",
                newName: "PhysicsDataTable");

            migrationBuilder.RenameColumn(
                name: "Data_Timestamp",
                table: "PhysicsDataTable",
                newName: "DataTimestamp");

            migrationBuilder.RenameColumn(
                name: "Data_Id",
                table: "PhysicsDataTable",
                newName: "DataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhysicsDataTable",
                table: "PhysicsDataTable",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AccGForces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Frontal = table.Column<float>(type: "real", nullable: false),
                    Horizontal = table.Column<float>(type: "real", nullable: false),
                    Vertical = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccGForces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WheelData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FrontLeft = table.Column<float>(type: "real", nullable: false),
                    FrontRight = table.Column<float>(type: "real", nullable: false),
                    RearLeft = table.Column<float>(type: "real", nullable: false),
                    RearRight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnassignedPhysicsData",
                columns: table => new
                {
                    Timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccGForcesId = table.Column<Guid>(type: "uuid", nullable: false),
                    CamberRadId = table.Column<Guid>(type: "uuid", nullable: false),
                    DyId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadId = table.Column<Guid>(type: "uuid", nullable: false),
                    MzId = table.Column<Guid>(type: "uuid", nullable: false),
                    NdSlipId = table.Column<Guid>(type: "uuid", nullable: false),
                    SlipAngleContactPatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    SlipAngleId = table.Column<Guid>(type: "uuid", nullable: false),
                    SlipRatioId = table.Column<Guid>(type: "uuid", nullable: false),
                    SuspensionHeightId = table.Column<Guid>(type: "uuid", nullable: false),
                    TyreDirtyLevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    TyreLoadedRadiusId = table.Column<Guid>(type: "uuid", nullable: false),
                    TyreRadiusId = table.Column<Guid>(type: "uuid", nullable: false),
                    TyreSlipId = table.Column<Guid>(type: "uuid", nullable: false),
                    WheelAngularSpeedId = table.Column<Guid>(type: "uuid", nullable: false),
                    Brake = table.Column<float>(type: "real", nullable: false),
                    CarCoordinates = table.Column<List<float>>(type: "real[]", nullable: false),
                    CarPositionNormalized = table.Column<float>(type: "real", nullable: false),
                    CarSlope = table.Column<float>(type: "real", nullable: false),
                    CgHeight = table.Column<float>(type: "real", nullable: false),
                    Clutch = table.Column<float>(type: "real", nullable: false),
                    EngineRpm = table.Column<float>(type: "real", nullable: false),
                    Gear = table.Column<int>(type: "integer", nullable: false),
                    Identifier = table.Column<int>(type: "integer", nullable: false),
                    InPit = table.Column<bool>(type: "boolean", nullable: false),
                    IsAbsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsAbsInAction = table.Column<bool>(type: "boolean", nullable: false),
                    IsEngineLimiterOn = table.Column<bool>(type: "boolean", nullable: false),
                    IsTcEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsTcInAction = table.Column<bool>(type: "boolean", nullable: false),
                    LapCount = table.Column<int>(type: "integer", nullable: false),
                    LapTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    SpeedKmh = table.Column<float>(type: "real", nullable: false),
                    SpeedMph = table.Column<float>(type: "real", nullable: false),
                    SpeedMs = table.Column<float>(type: "real", nullable: false),
                    Steering = table.Column<float>(type: "real", nullable: false),
                    Throttle = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnassignedPhysicsData", x => new { x.Timestamp, x.Id });
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_AccGForces_AccGForcesId",
                        column: x => x.AccGForcesId,
                        principalTable: "AccGForces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_CamberRadId",
                        column: x => x.CamberRadId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_DyId",
                        column: x => x.DyId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_LoadId",
                        column: x => x.LoadId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_MzId",
                        column: x => x.MzId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_NdSlipId",
                        column: x => x.NdSlipId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_SlipAngleContactPatchId",
                        column: x => x.SlipAngleContactPatchId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_SlipAngleId",
                        column: x => x.SlipAngleId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_SlipRatioId",
                        column: x => x.SlipRatioId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_SuspensionHeightId",
                        column: x => x.SuspensionHeightId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_TyreDirtyLevelId",
                        column: x => x.TyreDirtyLevelId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_TyreLoadedRadiusId",
                        column: x => x.TyreLoadedRadiusId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_TyreRadiusId",
                        column: x => x.TyreRadiusId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_TyreSlipId",
                        column: x => x.TyreSlipId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnassignedPhysicsData_WheelData_WheelAngularSpeedId",
                        column: x => x.WheelAngularSpeedId,
                        principalTable: "WheelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhysicsDataTable_DataTimestamp_DataId",
                table: "PhysicsDataTable",
                columns: new[] { "DataTimestamp", "DataId" });

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_AccGForcesId",
                table: "UnassignedPhysicsData",
                column: "AccGForcesId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_CamberRadId",
                table: "UnassignedPhysicsData",
                column: "CamberRadId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_DyId",
                table: "UnassignedPhysicsData",
                column: "DyId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_LoadId",
                table: "UnassignedPhysicsData",
                column: "LoadId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_MzId",
                table: "UnassignedPhysicsData",
                column: "MzId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_NdSlipId",
                table: "UnassignedPhysicsData",
                column: "NdSlipId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_SlipAngleContactPatchId",
                table: "UnassignedPhysicsData",
                column: "SlipAngleContactPatchId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_SlipAngleId",
                table: "UnassignedPhysicsData",
                column: "SlipAngleId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_SlipRatioId",
                table: "UnassignedPhysicsData",
                column: "SlipRatioId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_SuspensionHeightId",
                table: "UnassignedPhysicsData",
                column: "SuspensionHeightId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_TyreDirtyLevelId",
                table: "UnassignedPhysicsData",
                column: "TyreDirtyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_TyreLoadedRadiusId",
                table: "UnassignedPhysicsData",
                column: "TyreLoadedRadiusId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_TyreRadiusId",
                table: "UnassignedPhysicsData",
                column: "TyreRadiusId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_TyreSlipId",
                table: "UnassignedPhysicsData",
                column: "TyreSlipId");

            migrationBuilder.CreateIndex(
                name: "IX_UnassignedPhysicsData_WheelAngularSpeedId",
                table: "UnassignedPhysicsData",
                column: "WheelAngularSpeedId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicsDataTable_UnassignedPhysicsData_DataTimestamp_DataId",
                table: "PhysicsDataTable",
                columns: new[] { "DataTimestamp", "DataId" },
                principalTable: "UnassignedPhysicsData",
                principalColumns: new[] { "Timestamp", "Id" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
