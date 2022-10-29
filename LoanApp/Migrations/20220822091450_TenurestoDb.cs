using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanApp.Migrations
{
    public partial class TenurestoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenures",
                columns: table => new
                {
                    tenureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    months = table.Column<int>(type: "int", nullable: false),
                    loanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenures", x => x.tenureId);
                    table.ForeignKey(
                        name: "FK_Tenures_Loans_loanId",
                        column: x => x.loanId,
                        principalTable: "Loans",
                        principalColumn: "loanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenures_loanId",
                table: "Tenures",
                column: "loanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenures");
        }
    }
}
