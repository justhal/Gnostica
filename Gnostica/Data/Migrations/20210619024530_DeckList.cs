using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class DeckList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DeckList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardID = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    DeckListID = table.Column<int>(nullable: true),
                    GameID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DeckList_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeckList_DeckList_DeckListID",
                        column: x => x.DeckListID,
                        principalTable: "DeckList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeckList_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckList_CardID",
                table: "DeckList",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_DeckList_DeckListID",
                table: "DeckList",
                column: "DeckListID");

            migrationBuilder.CreateIndex(
                name: "IX_DeckList_GameID",
                table: "DeckList",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeckList");

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "Cards",
                type: "int",
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
    }
}
