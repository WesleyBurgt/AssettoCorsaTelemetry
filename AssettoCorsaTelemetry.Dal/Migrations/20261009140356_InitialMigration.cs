using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssettoCorsaTelemetry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccGForces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Vertical = table.Column<float>(type: "real", nullable: false),
                    Horizontal = table.Column<float>(type: "real", nullable: false),
                    Frontal = table.Column<float>(type: "real", nullable: false)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Identifier = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    SpeedKmh = table.Column<float>(type: "real", nullable: false),
                    SpeedMph = table.Column<float>(type: "real", nullable: false),
                    SpeedMs = table.Column<float>(type: "real", nullable: false),
                    IsAbsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsAbsInAction = table.Column<bool>(type: "boolean", nullable: false),
                    IsTcInAction = table.Column<bool>(type: "boolean", nullable: false),
                    IsTcEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    InPit = table.Column<bool>(type: "boolean", nullable: false),
                    IsEngineLimiterOn = table.Column<bool>(type: "boolean", nullable: false),
                    AccGForcesId = table.Column<Guid>(type: "uuid", nullable: false),
                    LapTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    LapCount = table.Column<int>(type: "integer", nullable: false),
                    Throttle = table.Column<float>(type: "real", nullable: false),
                    Brake = table.Column<float>(type: "real", nullable: false),
                    Clutch = table.Column<float>(type: "real", nullable: false),
                    EngineRpm = table.Column<float>(type: "real", nullable: false),
                    Steering = table.Column<float>(type: "real", nullable: false),
                    Gear = table.Column<int>(type: "integer", nullable: false),
                    CgHeight = table.Column<float>(type: "real", nullable: false),
                    WheelAngularSpeedId = table.Column<Guid>(type: "uuid", nullable: false),
                    SlipAngleId = table.Column<Guid>(type: "uuid", nullable: false),
                    SlipAngleContactPatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    SlipRatioId = table.Column<Guid>(type: "uuid", nullable: false),
                    TyreSlipId = table.Column<Guid>(type: "uuid", nullable: false),
                    NdSlipId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadId = table.Column<Guid>(type: "uuid", nullable: false),
                    DyId = table.Column<Guid>(type: "uuid", nullable: false),
                    MzId = table.Column<Guid>(type: "uuid", nullable: false),
                    TyreDirtyLevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    CamberRadId = table.Column<Guid>(type: "uuid", nullable: false),
                    TyreRadiusId = table.Column<Guid>(type: "uuid", nullable: false),
                    TyreLoadedRadiusId = table.Column<Guid>(type: "uuid", nullable: false),
                    SuspensionHeightId = table.Column<Guid>(type: "uuid", nullable: false),
                    CarPositionNormalized = table.Column<float>(type: "real", nullable: false),
                    CarSlope = table.Column<float>(type: "real", nullable: false),
                    CarCoordinates = table.Column<List<float>>(type: "real[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnassignedPhysicsData", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "PhysicsDataTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrackId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicsDataTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicsDataTable_UnassignedPhysicsData_DataId",
                        column: x => x.DataId,
                        principalTable: "UnassignedPhysicsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhysicsDataTable_DataId",
                table: "PhysicsDataTable",
                column: "DataId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhysicsDataTable");

            migrationBuilder.DropTable(
                name: "UnassignedPhysicsData");

            migrationBuilder.DropTable(
                name: "AccGForces");

            migrationBuilder.DropTable(
                name: "WheelData");
        }
    }
}
