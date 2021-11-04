using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class PlayerColorToPlayerPieceColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "PieceColor",
                table: "Players",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PieceColor",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
