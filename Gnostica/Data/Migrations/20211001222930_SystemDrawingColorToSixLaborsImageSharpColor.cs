using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class SystemDrawingColorToSixLaborsImageSharpColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PieceColor",
                table: "PlayerGame",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PieceColor",
                table: "PlayerGame",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
