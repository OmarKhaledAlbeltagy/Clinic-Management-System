using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class Clinic20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientProfileId",
                table: "PreAppointment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreAppointment_PatientProfileId",
                table: "PreAppointment",
                column: "PatientProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreAppointment_PatientProfile_PatientProfileId",
                table: "PreAppointment",
                column: "PatientProfileId",
                principalTable: "PatientProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreAppointment_PatientProfile_PatientProfileId",
                table: "PreAppointment");

            migrationBuilder.DropIndex(
                name: "IX_PreAppointment_PatientProfileId",
                table: "PreAppointment");

            migrationBuilder.DropColumn(
                name: "PatientProfileId",
                table: "PreAppointment");
        }
    }
}
