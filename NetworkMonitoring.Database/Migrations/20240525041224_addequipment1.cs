using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkMonitoring.Database.Migrations
{
    /// <inheritdoc />
    public partial class addequipment1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bs_EquipmentLocation",
                columns: table => new
                {
                    EquipmentLocationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentLocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bs_EquipmentLocation", x => x.EquipmentLocationID);
                });

            migrationBuilder.CreateTable(
                name: "Bs_EquipmentType",
                columns: table => new
                {
                    EquipmentTypeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentTypeImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bs_EquipmentType", x => x.EquipmentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Srv_EquipmentIP",
                columns: table => new
                {
                    EquipmentIPID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentIPName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    EquipmentLocationID = table.Column<long>(type: "bigint", nullable: false),
                    EquipmentTypeID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Srv_EquipmentIP", x => x.EquipmentIPID);
                    table.ForeignKey(
                        name: "FK_Srv_EquipmentIP_Bs_EquipmentLocation_EquipmentLocationID",
                        column: x => x.EquipmentLocationID,
                        principalTable: "Bs_EquipmentLocation",
                        principalColumn: "EquipmentLocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Srv_EquipmentIP_Bs_EquipmentType_EquipmentTypeID",
                        column: x => x.EquipmentTypeID,
                        principalTable: "Bs_EquipmentType",
                        principalColumn: "EquipmentTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Srv_EquipmentIP_EquipmentLocationID",
                table: "Srv_EquipmentIP",
                column: "EquipmentLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Srv_EquipmentIP_EquipmentTypeID",
                table: "Srv_EquipmentIP",
                column: "EquipmentTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Srv_EquipmentIP");

            migrationBuilder.DropTable(
                name: "Bs_EquipmentLocation");

            migrationBuilder.DropTable(
                name: "Bs_EquipmentType");
        }
    }
}
