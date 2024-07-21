using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class clinic4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExaminationDiscount",
                table: "InsurancePackage");

            migrationBuilder.DropColumn(
                name: "ExaminationDiscountRate",
                table: "InsurancePackage");

            migrationBuilder.DropColumn(
                name: "FollowupDiscount",
                table: "InsurancePackage");

            migrationBuilder.DropColumn(
                name: "FollowupDiscountRate",
                table: "InsurancePackage");

            migrationBuilder.DropColumn(
                name: "OperationDiscount",
                table: "InsurancePackage");

            migrationBuilder.DropColumn(
                name: "OperationDiscountRate",
                table: "InsurancePackage");

            migrationBuilder.AddColumn<decimal>(
                name: "ExaminationPaidByInsurance",
                table: "InsurancePackage",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExaminationPaidByPatient",
                table: "InsurancePackage",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExaminationTotalPrice",
                table: "InsurancePackage",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FollowupPaidByInsurance",
                table: "InsurancePackage",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FollowupPaidByPatient",
                table: "InsurancePackage",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FollowupTotalPrice",
                table: "InsurancePackage",
                type: "money",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InsurancePackageOperation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsurancePackageId = table.Column<int>(nullable: false),
                    OperationId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: true),
                    PaidByPatient = table.Column<decimal>(type: "money", nullable: true),
                    PaidByInsurance = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePackageOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurancePackageOperation_InsurancePackage_InsurancePackageId",
                        column: x => x.InsurancePackageId,
                        principalTable: "InsurancePackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsurancePackageOperation_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePackageOperation_InsurancePackageId",
                table: "InsurancePackageOperation",
                column: "InsurancePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePackageOperation_OperationId",
                table: "InsurancePackageOperation",
                column: "OperationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsurancePackageOperation");

            migrationBuilder.DropColumn(
                name: "ExaminationPaidByInsurance",
                table: "InsurancePackage");

            migrationBuilder.DropColumn(
                name: "ExaminationPaidByPatient",
                table: "InsurancePackage");

            migrationBuilder.DropColumn(
                name: "ExaminationTotalPrice",
                table: "InsurancePackage");

            migrationBuilder.DropColumn(
                name: "FollowupPaidByInsurance",
                table: "InsurancePackage");

            migrationBuilder.DropColumn(
                name: "FollowupPaidByPatient",
                table: "InsurancePackage");

            migrationBuilder.DropColumn(
                name: "FollowupTotalPrice",
                table: "InsurancePackage");

            migrationBuilder.AddColumn<bool>(
                name: "ExaminationDiscount",
                table: "InsurancePackage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "ExaminationDiscountRate",
                table: "InsurancePackage",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FollowupDiscount",
                table: "InsurancePackage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "FollowupDiscountRate",
                table: "InsurancePackage",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OperationDiscount",
                table: "InsurancePackage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "OperationDiscountRate",
                table: "InsurancePackage",
                nullable: true);
        }
    }
}
