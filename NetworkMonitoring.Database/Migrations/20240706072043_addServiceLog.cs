using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkMonitoring.Database.Migrations
{
    /// <inheritdoc />
    public partial class addServiceLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log_NetworkService",
                columns: table => new
                {
                    NetworkServiceLogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DownTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NetworkServiceID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_NetworkService", x => x.NetworkServiceLogID);
                    table.ForeignKey(
                        name: "FK_Log_NetworkService_Srv_NetworkService_NetworkServiceID",
                        column: x => x.NetworkServiceID,
                        principalTable: "Srv_NetworkService",
                        principalColumn: "NetworkServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_NetworkService_NetworkServiceID",
                table: "Log_NetworkService",
                column: "NetworkServiceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log_NetworkService");
        }
    }
}
