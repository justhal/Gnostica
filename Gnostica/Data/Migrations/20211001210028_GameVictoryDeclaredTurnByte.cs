using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class GameVictoryDeclaredTurnByte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "VictoryDeclaredTurn",
                table: "Games",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VictoryDeclaredTurn",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(byte),
                oldNullable: true);
        }
    }
}
