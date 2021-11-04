using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class CreateDiscards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscardsID",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_DiscardsID",
                table: "Games",
                column: "DiscardsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Decks_DiscardsID",
                table: "Games",
                column: "DiscardsID",
                principalTable: "Decks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Decks_DiscardsID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_DiscardsID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DiscardsID",
                table: "Games");
        }
    }
}
