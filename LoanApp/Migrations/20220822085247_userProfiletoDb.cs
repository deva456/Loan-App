using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanApp.Migrations
{
    public partial class userProfiletoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userProfiles",
                columns: table => new
                {
                    profileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    income = table.Column<double>(type: "float", nullable: false),
                    idProof = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loanAmount = table.Column<double>(type: "float", nullable: false),
                    tenure = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userProfiles", x => x.profileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userProfiles");
        }
    }
}
