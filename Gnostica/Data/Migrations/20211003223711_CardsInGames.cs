using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class CardsInGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardList_Games_GameID",
                table: "CardList");

            migrationBuilder.DropIndex(
                name: "IX_CardList_GameID",
                table: "CardList");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "CardList");

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "Cards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_GameID",
                table: "Cards",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Games_GameID",
                table: "Cards",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Games_GameID",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_GameID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "CardList",
                type: "int",
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
    }
}
