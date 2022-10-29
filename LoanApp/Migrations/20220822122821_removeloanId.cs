using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanApp.Migrations
{
    public partial class removeloanId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenures_Loans_loanId",
                table: "Tenures");

            migrationBuilder.DropIndex(
                name: "IX_Tenures_loanId",
                table: "Tenures");

            migrationBuilder.DropColumn(
                name: "loanId",
                table: "Tenures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "loanId",
                table: "Tenures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tenures_loanId",
                table: "Tenures",
                column: "loanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenures_Loans_loanId",
                table: "Tenures",
                column: "loanId",
                principalTable: "Loans",
                principalColumn: "loanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
