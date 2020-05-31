using Microsoft.EntityFrameworkCore.Migrations;

namespace Prev.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Decimal",
                table: "User",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PlanHealthId",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlanHealths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanHealths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanHealths_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_PlanHealthId",
                table: "User",
                column: "PlanHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanHealths_CompanyId",
                table: "PlanHealths",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_PlanHealths_PlanHealthId",
                table: "User",
                column: "PlanHealthId",
                principalTable: "PlanHealths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_PlanHealths_PlanHealthId",
                table: "User");

            migrationBuilder.DropTable(
                name: "PlanHealths");

            migrationBuilder.DropIndex(
                name: "IX_User_PlanHealthId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Decimal",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PlanHealthId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "User");
        }
    }
}
