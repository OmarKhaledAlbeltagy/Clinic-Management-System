using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class Clinic12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExtenIdentityUserId",
                table: "workingTime",
                newName: "extenidentityuserid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "extenidentityuserid",
                table: "workingTime",
                newName: "ExtenIdentityUserId");
        }
    }
}
