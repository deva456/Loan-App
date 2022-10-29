using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanApp.Migrations
{
    public partial class rrmovetenure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tenure",
                table: "userProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tenure",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
