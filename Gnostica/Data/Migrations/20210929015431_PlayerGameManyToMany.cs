using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class PlayerGameManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardList_Players_PlayerID",
                table: "CardList");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Players_PlayerID",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Games_GameID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_GameID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Piece_PlayerID",
                table: "Piece");

            migrationBuilder.DropIndex(
                name: "IX_CardList_PlayerID",
                table: "CardList");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PieceColor",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "Piece");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "CardList");

            migrationBuilder.AddColumn<int>(
                name: "PlayerGameGameID",
                table: "Piece",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerGamePlayerID",
                table: "Piece",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerGameGameID",
                table: "CardList",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerGamePlayerID",
                table: "CardList",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayerGame",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: false),
                    PieceColor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGame", x => new { x.PlayerID, x.GameID });
                    table.ForeignKey(
                        name: "FK_PlayerGame_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piece_PlayerGamePlayerID_PlayerGameGameID",
                table: "Piece",
                columns: new[] { "PlayerGamePlayerID", "PlayerGameGameID" });

            migrationBuilder.CreateIndex(
                name: "IX_CardList_PlayerGamePlayerID_PlayerGameGameID",
                table: "CardList",
                columns: new[] { "PlayerGamePlayerID", "PlayerGameGameID" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_GameID",
                table: "PlayerGame",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardList_PlayerGame_PlayerGamePlayerID_PlayerGameGameID",
                table: "CardList",
                columns: new[] { "PlayerGamePlayerID", "PlayerGameGameID" },
                principalTable: "PlayerGame",
                principalColumns: new[] { "PlayerID", "GameID" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_PlayerGame_PlayerGamePlayerID_PlayerGameGameID",
                table: "Piece",
                columns: new[] { "PlayerGamePlayerID", "PlayerGameGameID" },
                principalTable: "PlayerGame",
                principalColumns: new[] { "PlayerID", "GameID" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardList_PlayerGame_PlayerGamePlayerID_PlayerGameGameID",
                table: "CardList");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_PlayerGame_PlayerGamePlayerID_PlayerGameGameID",
                table: "Piece");

            migrationBuilder.DropTable(
                name: "PlayerGame");

            migrationBuilder.DropIndex(
                name: "IX_Piece_PlayerGamePlayerID_PlayerGameGameID",
                table: "Piece");

            migrationBuilder.DropIndex(
                name: "IX_CardList_PlayerGamePlayerID_PlayerGameGameID",
                table: "CardList");

            migrationBuilder.DropColumn(
                name: "PlayerGameGameID",
                table: "Piece");

            migrationBuilder.DropColumn(
                name: "PlayerGamePlayerID",
                table: "Piece");

            migrationBuilder.DropColumn(
                name: "PlayerGameGameID",
                table: "CardList");

            migrationBuilder.DropColumn(
                name: "PlayerGamePlayerID",
                table: "CardList");

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PieceColor",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "Piece",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "CardList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameID",
                table: "Players",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_PlayerID",
                table: "Piece",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_CardList_PlayerID",
                table: "CardList",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardList_Players_PlayerID",
                table: "CardList",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Players_PlayerID",
                table: "Piece",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Games_GameID",
                table: "Players",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
