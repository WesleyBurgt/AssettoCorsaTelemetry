using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssettoCorsaTelemetry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureTimescaleDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "CREATE EXTENSION IF NOT EXISTS timescaledb;");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PhysicsDataTable_UnassignedPhysicsData_DataId",
                table: "PhysicsDataTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnassignedPhysicsData",
                table: "UnassignedPhysicsData");

            migrationBuilder.DropIndex(
                name: "IX_PhysicsDataTable_DataId",
                table: "PhysicsDataTable");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "UnassignedPhysicsData");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataTimestamp",
                table: "PhysicsDataTable",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnassignedPhysicsData",
                table: "UnassignedPhysicsData",
                columns: new[] { "Timestamp", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_PhysicsDataTable_DataTimestamp_DataId",
                table: "PhysicsDataTable",
                columns: new[] { "DataTimestamp", "DataId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicsDataTable_UnassignedPhysicsData_DataTimestamp_DataId",
                table: "PhysicsDataTable",
                columns: new[] { "DataTimestamp", "DataId" },
                principalTable: "UnassignedPhysicsData",
                principalColumns: new[] { "Timestamp", "Id" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhysicsDataTable_UnassignedPhysicsData_DataTimestamp_DataId",
                table: "PhysicsDataTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnassignedPhysicsData",
                table: "UnassignedPhysicsData");

            migrationBuilder.DropIndex(
                name: "IX_PhysicsDataTable_DataTimestamp_DataId",
                table: "PhysicsDataTable");

            migrationBuilder.DropColumn(
                name: "DataTimestamp",
                table: "PhysicsDataTable");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "UnassignedPhysicsData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnassignedPhysicsData",
                table: "UnassignedPhysicsData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicsDataTable_DataId",
                table: "PhysicsDataTable",
                column: "DataId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicsDataTable_UnassignedPhysicsData_DataId",
                table: "PhysicsDataTable",
                column: "DataId",
                principalTable: "UnassignedPhysicsData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
