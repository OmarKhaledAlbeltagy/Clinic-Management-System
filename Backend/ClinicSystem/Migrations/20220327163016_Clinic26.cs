using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class Clinic26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VacationId",
                table: "appointmentsToCancel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_appointmentsToCancel_VacationId",
                table: "appointmentsToCancel",
                column: "VacationId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointmentsToCancel_vacation_VacationId",
                table: "appointmentsToCancel",
                column: "VacationId",
                principalTable: "vacation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointmentsToCancel_vacation_VacationId",
                table: "appointmentsToCancel");

            migrationBuilder.DropIndex(
                name: "IX_appointmentsToCancel_VacationId",
                table: "appointmentsToCancel");

            migrationBuilder.DropColumn(
                name: "VacationId",
                table: "appointmentsToCancel");
        }
    }
}
