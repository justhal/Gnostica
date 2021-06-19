using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class DeckNotGeneric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckLists_DeckLists_DeckListID",
                table: "DeckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_DeckLists_Games_GameID",
                table: "DeckLists");

            migrationBuilder.DropIndex(
                name: "IX_DeckLists_DeckListID",
                table: "DeckLists");

            migrationBuilder.DropIndex(
                name: "IX_DeckLists_GameID",
                table: "DeckLists");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "DeckListID",
                table: "DeckLists");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "DeckLists");

            migrationBuilder.AddColumn<int>(
                name: "DeckID",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeckID",
                table: "DeckLists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeckID",
                table: "Games",
                column: "DeckID");

            migrationBuilder.CreateIndex(
                name: "IX_DeckLists_DeckID",
                table: "DeckLists",
                column: "DeckID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckLists_Decks_DeckID",
                table: "DeckLists",
                column: "DeckID",
                principalTable: "Decks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Decks_DeckID",
                table: "Games",
                column: "DeckID",
                principalTable: "Decks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckLists_Decks_DeckID",
                table: "DeckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Decks_DeckID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_DeckID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_DeckLists_DeckID",
                table: "DeckLists");

            migrationBuilder.DropColumn(
                name: "DeckID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DeckID",
                table: "DeckLists");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeckListID",
                table: "DeckLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "DeckLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeckLists_DeckListID",
                table: "DeckLists",
                column: "DeckListID");

            migrationBuilder.CreateIndex(
                name: "IX_DeckLists_GameID",
                table: "DeckLists",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckLists_DeckLists_DeckListID",
                table: "DeckLists",
                column: "DeckListID",
                principalTable: "DeckLists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeckLists_Games_GameID",
                table: "DeckLists",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
