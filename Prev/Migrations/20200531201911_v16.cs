using Microsoft.EntityFrameworkCore.Migrations;

namespace Prev.Migrations
{
    public partial class v16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decimal",
                table: "User");

            migrationBuilder.AddColumn<decimal>(
                name: "Investiment",
                table: "User",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Investiment",
                table: "User");

            migrationBuilder.AddColumn<decimal>(
                name: "Decimal",
                table: "User",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
