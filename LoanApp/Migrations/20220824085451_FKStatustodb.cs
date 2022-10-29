using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanApp.Migrations
{
    public partial class FKStatustodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "statusId",
                table: "userProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userProfiles_statusId",
                table: "userProfiles",
                column: "statusId");

            migrationBuilder.AddForeignKey(
                name: "FK_userProfiles_Statuses_statusId",
                table: "userProfiles",
                column: "statusId",
                principalTable: "Statuses",
                principalColumn: "statusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userProfiles_Statuses_statusId",
                table: "userProfiles");

            migrationBuilder.DropIndex(
                name: "IX_userProfiles_statusId",
                table: "userProfiles");

            migrationBuilder.DropColumn(
                name: "statusId",
                table: "userProfiles");
        }
    }
}
