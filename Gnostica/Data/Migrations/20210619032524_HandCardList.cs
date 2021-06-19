using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class HandCardList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckList_Cards_CardID",
                table: "DeckList");

            migrationBuilder.DropForeignKey(
                name: "FK_DeckList_DeckList_DeckListID",
                table: "DeckList");

            migrationBuilder.DropForeignKey(
                name: "FK_DeckList_Games_GameID",
                table: "DeckList");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Games_GameID",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeckList",
                table: "DeckList");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "DeckList",
                newName: "DeckLists");

            migrationBuilder.RenameIndex(
                name: "IX_Player_GameID",
                table: "Players",
                newName: "IX_Players_GameID");

            migrationBuilder.RenameIndex(
                name: "IX_DeckList_GameID",
                table: "DeckLists",
                newName: "IX_DeckLists_GameID");

            migrationBuilder.RenameIndex(
                name: "IX_DeckList_DeckListID",
                table: "DeckLists",
                newName: "IX_DeckLists_DeckListID");

            migrationBuilder.RenameIndex(
                name: "IX_DeckList_CardID",
                table: "DeckLists",
                newName: "IX_DeckLists_CardID");

            migrationBuilder.AddColumn<bool>(
                name: "Stash",
                table: "Location",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Games",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeckLists",
                table: "DeckLists",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "CardList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardID = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: true)
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
                        name: "FK_CardList_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Piece",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationID = table.Column<int>(nullable: true),
                    Orientation_direction = table.Column<int>(nullable: true),
                    PlayerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piece", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Piece_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardList_CardID",
                table: "CardList",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_CardList_PlayerID",
                table: "CardList",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_LocationID",
                table: "Piece",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_PlayerID",
                table: "Piece",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckLists_Cards_CardID",
                table: "DeckLists",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Games_GameID",
                table: "Players",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckLists_Cards_CardID",
                table: "DeckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_DeckLists_DeckLists_DeckListID",
                table: "DeckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_DeckLists_Games_GameID",
                table: "DeckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Games_GameID",
                table: "Players");

            migrationBuilder.DropTable(
                name: "CardList");

            migrationBuilder.DropTable(
                name: "Piece");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeckLists",
                table: "DeckLists");

            migrationBuilder.DropColumn(
                name: "Stash",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "DeckLists",
                newName: "DeckList");

            migrationBuilder.RenameIndex(
                name: "IX_Players_GameID",
                table: "Player",
                newName: "IX_Player_GameID");

            migrationBuilder.RenameIndex(
                name: "IX_DeckLists_GameID",
                table: "DeckList",
                newName: "IX_DeckList_GameID");

            migrationBuilder.RenameIndex(
                name: "IX_DeckLists_DeckListID",
                table: "DeckList",
                newName: "IX_DeckList_DeckListID");

            migrationBuilder.RenameIndex(
                name: "IX_DeckLists_CardID",
                table: "DeckList",
                newName: "IX_DeckList_CardID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeckList",
                table: "DeckList",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckList_Cards_CardID",
                table: "DeckList",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeckList_DeckList_DeckListID",
                table: "DeckList",
                column: "DeckListID",
                principalTable: "DeckList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeckList_Games_GameID",
                table: "DeckList",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Games_GameID",
                table: "Player",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
