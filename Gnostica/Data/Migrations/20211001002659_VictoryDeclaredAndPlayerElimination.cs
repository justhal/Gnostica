using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class VictoryDeclaredAndPlayerElimination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminated",
                table: "PlayerGame",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "cardLocation",
                table: "Location",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Turn",
                table: "Games",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "VictoryDeclared",
                table: "Games",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VictoryDeclaredRound",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VictoryDeclaredTurn",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "CardList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardList_GameID",
                table: "CardList",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardList_Games_GameID",
                table: "CardList",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardList_Games_GameID",
                table: "CardList");

            migrationBuilder.DropIndex(
                name: "IX_CardList_GameID",
                table: "CardList");

            migrationBuilder.DropColumn(
                name: "Eliminated",
                table: "PlayerGame");

            migrationBuilder.DropColumn(
                name: "cardLocation",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "VictoryDeclared",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "VictoryDeclaredRound",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "VictoryDeclaredTurn",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "CardList");

            migrationBuilder.AlterColumn<int>(
                name: "Turn",
                table: "Games",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
