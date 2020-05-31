using Microsoft.EntityFrameworkCore.Migrations;

namespace Prev.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Code",
                table: "Plan",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Plan",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Target = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plan_CompanyId",
                table: "Plan",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Companies_CompanyId",
                table: "Plan",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Companies_CompanyId",
                table: "Plan");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Plan_CompanyId",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Plan");
        }
    }
}
