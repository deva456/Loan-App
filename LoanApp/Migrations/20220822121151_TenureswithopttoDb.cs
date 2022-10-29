using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanApp.Migrations
{
    public partial class TenureswithopttoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tenure",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "occupation",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "idProof",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "months",
                table: "userProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tenure Id",
                table: "userProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userProfiles_tenure Id",
                table: "userProfiles",
                column: "tenure Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userProfiles_Tenures_tenure Id",
                table: "userProfiles",
                column: "tenure Id",
                principalTable: "Tenures",
                principalColumn: "tenureId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userProfiles_Tenures_tenure Id",
                table: "userProfiles");

            migrationBuilder.DropIndex(
                name: "IX_userProfiles_tenure Id",
                table: "userProfiles");

            migrationBuilder.DropColumn(
                name: "months",
                table: "userProfiles");

            migrationBuilder.DropColumn(
                name: "tenure Id",
                table: "userProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "tenure",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "occupation",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "idProof",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
