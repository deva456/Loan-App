using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanApp.Migrations
{
    public partial class FKtoprofileDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "loanId",
                table: "userProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userProfiles_loanId",
                table: "userProfiles",
                column: "loanId");

            migrationBuilder.AddForeignKey(
                name: "FK_userProfiles_Loans_loanId",
                table: "userProfiles",
                column: "loanId",
                principalTable: "Loans",
                principalColumn: "loanId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userProfiles_Loans_loanId",
                table: "userProfiles");

            migrationBuilder.DropIndex(
                name: "IX_userProfiles_loanId",
                table: "userProfiles");

            migrationBuilder.DropColumn(
                name: "loanId",
                table: "userProfiles");
        }
    }
}
