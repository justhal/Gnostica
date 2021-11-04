using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class AddedNumberOfPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumPlayers",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "Decks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decks_GameID",
                table: "Decks",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_Games_GameID",
                table: "Decks",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Games_GameID",
                table: "Decks");

            migrationBuilder.DropIndex(
                name: "IX_Decks_GameID",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "NumPlayers",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "Decks");
        }
    }
}
