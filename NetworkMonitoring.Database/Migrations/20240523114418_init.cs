using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkMonitoring.Database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sys_SystemObject",
                columns: table => new
                {
                    SystemObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    SystemObjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemObjectRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_SystemObject", x => x.SystemObjectID);
                });

            migrationBuilder.CreateTable(
                name: "Sys_SystemUserGroup",
                columns: table => new
                {
                    SystemUserGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemUserGroupTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_SystemUserGroup", x => x.SystemUserGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Sys_SystemUser",
                columns: table => new
                {
                    SystemUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemUserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemUserGroupID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_SystemUser", x => x.SystemUserID);
                    table.ForeignKey(
                        name: "FK_Sys_SystemUser_Sys_SystemUserGroup_SystemUserGroupID",
                        column: x => x.SystemUserGroupID,
                        principalTable: "Sys_SystemUserGroup",
                        principalColumn: "SystemUserGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sys_SystemUserAccessRole",
                columns: table => new
                {
                    SystemUserAccessRolesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemUserGroupID = table.Column<int>(type: "int", nullable: false),
                    SystemObjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_SystemUserAccessRole", x => x.SystemUserAccessRolesID);
                    table.ForeignKey(
                        name: "FK_Sys_SystemUserAccessRole_Sys_SystemObject_SystemObjectID",
                        column: x => x.SystemObjectID,
                        principalTable: "Sys_SystemObject",
                        principalColumn: "SystemObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sys_SystemUserAccessRole_Sys_SystemUserGroup_SystemUserGroupID",
                        column: x => x.SystemUserGroupID,
                        principalTable: "Sys_SystemUserGroup",
                        principalColumn: "SystemUserGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_SystemUser_SystemUserGroupID",
                table: "Sys_SystemUser",
                column: "SystemUserGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_SystemUserAccessRole_SystemObjectID",
                table: "Sys_SystemUserAccessRole",
                column: "SystemObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_SystemUserAccessRole_SystemUserGroupID",
                table: "Sys_SystemUserAccessRole",
                column: "SystemUserGroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_SystemUser");

            migrationBuilder.DropTable(
                name: "Sys_SystemUserAccessRole");

            migrationBuilder.DropTable(
                name: "Sys_SystemObject");

            migrationBuilder.DropTable(
                name: "Sys_SystemUserGroup");
        }
    }
}
