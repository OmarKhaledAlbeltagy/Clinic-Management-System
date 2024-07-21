using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class Clinic14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorProcessPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    extendidentityuserid = table.Column<string>(nullable: true),
                    processtypeid = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorProcessPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorProcessPrice_AspNetUsers_extendidentityuserid",
                        column: x => x.extendidentityuserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorProcessPrice_ProcessType_processtypeid",
                        column: x => x.processtypeid,
                        principalTable: "ProcessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorProcessPrice_extendidentityuserid",
                table: "DoctorProcessPrice",
                column: "extendidentityuserid");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorProcessPrice_processtypeid",
                table: "DoctorProcessPrice",
                column: "processtypeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorProcessPrice");
        }
    }
}
