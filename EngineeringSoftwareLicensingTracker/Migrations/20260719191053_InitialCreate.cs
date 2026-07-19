using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EngineeringSoftwareLicensingTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    FloatingLicenseId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUsedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalSlots = table.Column<int>(type: "integer", nullable: false),
                    SlotsOccupied = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licenses_FloatingLicense_FloatingLicenseId",
                        column: x => x.FloatingLicenseId,
                        principalTable: "FloatingLicense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkerEntityId = table.Column<int>(type: "integer", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Workers_WorkerEntityId",
                        column: x => x.WorkerEntityId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workplaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomName = table.Column<string>(type: "text", nullable: false),
                    WorkerEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workplaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workplaces_Workers_WorkerEntityId",
                        column: x => x.WorkerEntityId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NameLicense",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkerEntityId = table.Column<int>(type: "integer", nullable: true),
                    UserCloudLogin = table.Column<string>(type: "text", nullable: false),
                    DeviceLimit = table.Column<int>(type: "integer", nullable: false),
                    TotalSlots = table.Column<int>(type: "integer", nullable: false)
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
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkerEntityId = table.Column<int>(type: "integer", nullable: true),
                    ReservationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LicenseEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Licenses_LicenseEntityId",
                        column: x => x.LicenseEntityId,
                        principalTable: "Licenses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Workers_WorkerEntityId",
                        column: x => x.WorkerEntityId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NodeLockedLicense",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Localization = table.Column<string>(type: "text", nullable: false),
                    WorkplaceEntityId = table.Column<int>(type: "integer", nullable: true),
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
                name: "IX_Activities_WorkerEntityId",
                table: "Activities",
                column: "WorkerEntityId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LicenseEntityId",
                table: "Reservations",
                column: "LicenseEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_WorkerEntityId",
                table: "Reservations",
                column: "WorkerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Workplaces_WorkerEntityId",
                table: "Workplaces",
                column: "WorkerEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "NameLicense");

            migrationBuilder.DropTable(
                name: "NodeLockedLicense");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Workplaces");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "FloatingLicense");
        }
    }
}
