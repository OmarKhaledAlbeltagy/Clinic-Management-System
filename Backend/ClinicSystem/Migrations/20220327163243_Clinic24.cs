using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class Clinic24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointmentsToCancel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PreAppointmentId = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointmentsToCancel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointmentsToCancel_PreAppointment_PreAppointmentId",
                        column: x => x.PreAppointmentId,
                        principalTable: "PreAppointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DoctorId = table.Column<string>(nullable: true),
                    extendidentityuserId = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vacation_AspNetUsers_extendidentityuserId",
                        column: x => x.extendidentityuserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointmentsToCancel_PreAppointmentId",
                table: "appointmentsToCancel",
                column: "PreAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_vacation_extendidentityuserId",
                table: "vacation",
                column: "extendidentityuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointmentsToCancel");

            migrationBuilder.DropTable(
                name: "vacation");
        }
    }
}
