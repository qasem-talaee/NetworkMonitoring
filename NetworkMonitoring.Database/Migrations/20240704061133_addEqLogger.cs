using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkMonitoring.Database.Migrations
{
    /// <inheritdoc />
    public partial class addEqLogger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log_EquipmentILog",
                columns: table => new
                {
                    EquipmentLogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DownTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EquipmentIPID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_EquipmentILog", x => x.EquipmentLogID);
                    table.ForeignKey(
                        name: "FK_Log_EquipmentILog_Srv_EquipmentIP_EquipmentIPID",
                        column: x => x.EquipmentIPID,
                        principalTable: "Srv_EquipmentIP",
                        principalColumn: "EquipmentIPID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_EquipmentILog_EquipmentIPID",
                table: "Log_EquipmentILog",
                column: "EquipmentIPID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log_EquipmentILog");
        }
    }
}
