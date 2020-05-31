using Microsoft.EntityFrameworkCore.Migrations;

namespace Prev.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Target",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Target",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Target",
                table: "Plan",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Target",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Target",
                table: "Plan");

            migrationBuilder.AddColumn<string>(
                name: "Target",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
