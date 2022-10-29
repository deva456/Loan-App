using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanApp.Migrations
{
    public partial class raddtenureId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userProfiles_Tenures_tenure Id",
                table: "userProfiles");

            migrationBuilder.RenameColumn(
                name: "tenure Id",
                table: "userProfiles",
                newName: "tenureId");

            migrationBuilder.RenameIndex(
                name: "IX_userProfiles_tenure Id",
                table: "userProfiles",
                newName: "IX_userProfiles_tenureId");

            migrationBuilder.AddForeignKey(
                name: "FK_userProfiles_Tenures_tenureId",
                table: "userProfiles",
                column: "tenureId",
                principalTable: "Tenures",
                principalColumn: "tenureId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userProfiles_Tenures_tenureId",
                table: "userProfiles");

            migrationBuilder.RenameColumn(
                name: "tenureId",
                table: "userProfiles",
                newName: "tenure Id");

            migrationBuilder.RenameIndex(
                name: "IX_userProfiles_tenureId",
                table: "userProfiles",
                newName: "IX_userProfiles_tenure Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userProfiles_Tenures_tenure Id",
                table: "userProfiles",
                column: "tenure Id",
                principalTable: "Tenures",
                principalColumn: "tenureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
