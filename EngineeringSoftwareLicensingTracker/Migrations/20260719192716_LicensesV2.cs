using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineeringSoftwareLicensingTracker.Migrations
{
    /// <inheritdoc />
    public partial class LicensesV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_FloatingLicense_FloatingLicenseId",
                table: "Licenses");

            migrationBuilder.DropTable(
                name: "FloatingLicense");

            migrationBuilder.DropTable(
                name: "NameLicense");

            migrationBuilder.DropTable(
                name: "NodeLockedLicense");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_FloatingLicenseId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "FloatingLicenseId",
                table: "Licenses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FloatingLicenseId",
                table: "Licenses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "FloatingLicense",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Port = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloatingLicense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NameLicense",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkerEntityId = table.Column<int>(type: "integer", nullable: true),
                    DeviceLimit = table.Column<int>(type: "integer", nullable: false),
                    TotalSlots = table.Column<int>(type: "integer", nullable: false),
                    UserCloudLogin = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameLicense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NameLicense_Licenses_Id",
                        column: x => x.Id,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NameLicense_Workers_WorkerEntityId",
                        column: x => x.WorkerEntityId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NodeLockedLicense",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkplaceEntityId = table.Column<int>(type: "integer", nullable: true),
                    Localization = table.Column<string>(type: "text", nullable: false),
                    PrimaryUserID = table.Column<int>(type: "integer", nullable: false),
                    TotalSlots = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeLockedLicense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NodeLockedLicense_Licenses_Id",
                        column: x => x.Id,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NodeLockedLicense_Workplaces_WorkplaceEntityId",
                        column: x => x.WorkplaceEntityId,
                        principalTable: "Workplaces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_FloatingLicenseId",
                table: "Licenses",
                column: "FloatingLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_NameLicense_WorkerEntityId",
                table: "NameLicense",
                column: "WorkerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_NodeLockedLicense_WorkplaceEntityId",
                table: "NodeLockedLicense",
                column: "WorkplaceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_FloatingLicense_FloatingLicenseId",
                table: "Licenses",
                column: "FloatingLicenseId",
                principalTable: "FloatingLicense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
