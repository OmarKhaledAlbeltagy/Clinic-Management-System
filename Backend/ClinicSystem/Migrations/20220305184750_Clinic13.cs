using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class Clinic13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workingTime_AspNetUsers_extendIdentityUserId",
                table: "workingTime");

            migrationBuilder.RenameColumn(
                name: "extendIdentityUserId",
                table: "workingTime",
                newName: "extendidentityuserId");

            migrationBuilder.RenameIndex(
                name: "IX_workingTime_extendIdentityUserId",
                table: "workingTime",
                newName: "IX_workingTime_extendidentityuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_workingTime_AspNetUsers_extendidentityuserId",
                table: "workingTime",
                column: "extendidentityuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workingTime_AspNetUsers_extendidentityuserId",
                table: "workingTime");

            migrationBuilder.RenameColumn(
                name: "extendidentityuserId",
                table: "workingTime",
                newName: "extendIdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_workingTime_extendidentityuserId",
                table: "workingTime",
                newName: "IX_workingTime_extendIdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_workingTime_AspNetUsers_extendIdentityUserId",
                table: "workingTime",
                column: "extendIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
