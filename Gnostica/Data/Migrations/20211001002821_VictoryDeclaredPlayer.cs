using Microsoft.EntityFrameworkCore.Migrations;

namespace Gnostica.Data.Migrations
{
    public partial class VictoryDeclaredPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VictoryDeclaredPlayerID",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_VictoryDeclaredPlayerID",
                table: "Games",
                column: "VictoryDeclaredPlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_VictoryDeclaredPlayerID",
                table: "Games",
                column: "VictoryDeclaredPlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_VictoryDeclaredPlayerID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_VictoryDeclaredPlayerID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "VictoryDeclaredPlayerID",
                table: "Games");
        }
    }
}
