using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class clinic5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePackageOperation_InsurancePackage_InsurancePackageId",
                table: "InsurancePackageOperation");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePackageOperation_Operation_OperationId",
                table: "InsurancePackageOperation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsurancePackageOperation",
                table: "InsurancePackageOperation");

            migrationBuilder.RenameTable(
                name: "InsurancePackageOperation",
                newName: "insurancePackageOperation");

            migrationBuilder.RenameIndex(
                name: "IX_InsurancePackageOperation_OperationId",
                table: "insurancePackageOperation",
                newName: "IX_insurancePackageOperation_OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_InsurancePackageOperation_InsurancePackageId",
                table: "insurancePackageOperation",
                newName: "IX_insurancePackageOperation_InsurancePackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_insurancePackageOperation",
                table: "insurancePackageOperation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_insurancePackageOperation_InsurancePackage_InsurancePackageId",
                table: "insurancePackageOperation",
                column: "InsurancePackageId",
                principalTable: "InsurancePackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_insurancePackageOperation_Operation_OperationId",
                table: "insurancePackageOperation",
                column: "OperationId",
                principalTable: "Operation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_insurancePackageOperation_InsurancePackage_InsurancePackageId",
                table: "insurancePackageOperation");

            migrationBuilder.DropForeignKey(
                name: "FK_insurancePackageOperation_Operation_OperationId",
                table: "insurancePackageOperation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_insurancePackageOperation",
                table: "insurancePackageOperation");

            migrationBuilder.RenameTable(
                name: "insurancePackageOperation",
                newName: "InsurancePackageOperation");

            migrationBuilder.RenameIndex(
                name: "IX_insurancePackageOperation_OperationId",
                table: "InsurancePackageOperation",
                newName: "IX_InsurancePackageOperation_OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_insurancePackageOperation_InsurancePackageId",
                table: "InsurancePackageOperation",
                newName: "IX_InsurancePackageOperation_InsurancePackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsurancePackageOperation",
                table: "InsurancePackageOperation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePackageOperation_InsurancePackage_InsurancePackageId",
                table: "InsurancePackageOperation",
                column: "InsurancePackageId",
                principalTable: "InsurancePackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePackageOperation_Operation_OperationId",
                table: "InsurancePackageOperation",
                column: "OperationId",
                principalTable: "Operation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
