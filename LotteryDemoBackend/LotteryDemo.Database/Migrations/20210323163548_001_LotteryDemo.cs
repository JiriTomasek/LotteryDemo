using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LotteryDemo.Database.Migrations
{
    public partial class _001_LotteryDemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrawHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrawNumber1 = table.Column<int>(type: "int", nullable: false),
                    DrawNumber2 = table.Column<int>(type: "int", nullable: false),
                    DrawNumber3 = table.Column<int>(type: "int", nullable: false),
                    DrawNumber4 = table.Column<int>(type: "int", nullable: false),
                    DrawNumber5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrawHistory");
        }
    }
}
