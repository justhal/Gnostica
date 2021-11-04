using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class DeckToCardList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardList");

            migrationBuilder.AddColumn<int>(
                name: "PlayerGameGameID",
                table: "DeckLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerGamePlayerID",
                table: "DeckLists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeckLists_PlayerGamePlayerID_PlayerGameGameID",
                table: "DeckLists",
                columns: new[] { "PlayerGamePlayerID", "PlayerGameGameID" });

            migrationBuilder.AddForeignKey(
                name: "FK_DeckLists_PlayerGame_PlayerGamePlayerID_PlayerGameGameID",
                table: "DeckLists",
                columns: new[] { "PlayerGamePlayerID", "PlayerGameGameID" },
                principalTable: "PlayerGame",
                principalColumns: new[] { "PlayerID", "GameID" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckLists_PlayerGame_PlayerGamePlayerID_PlayerGameGameID",
                table: "DeckLists");

            migrationBuilder.DropIndex(
                name: "IX_DeckLists_PlayerGamePlayerID_PlayerGameGameID",
                table: "DeckLists");

            migrationBuilder.DropColumn(
                name: "PlayerGameGameID",
                table: "DeckLists");

            migrationBuilder.DropColumn(
                name: "PlayerGamePlayerID",
                table: "DeckLists");

            migrationBuilder.CreateTable(
                name: "CardList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardID = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    PlayerGameGameID = table.Column<int>(type: "int", nullable: true),
                    PlayerGamePlayerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CardList_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardList_PlayerGame_PlayerGamePlayerID_PlayerGameGameID",
                        columns: x => new { x.PlayerGamePlayerID, x.PlayerGameGameID },
                        principalTable: "PlayerGame",
                        principalColumns: new[] { "PlayerID", "GameID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardList_CardID",
                table: "CardList",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_CardList_PlayerGamePlayerID_PlayerGameGameID",
                table: "CardList",
                columns: new[] { "PlayerGamePlayerID", "PlayerGameGameID" });
        }
    }
}
