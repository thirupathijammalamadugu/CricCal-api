using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Competition.API.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teams_TournamentId",
                table: "Teams",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Squads_TeamId",
                table: "Squads",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Squads_Teams_TeamId",
                table: "Squads",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tournaments_TournamentId",
                table: "Teams",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squads_Teams_TeamId",
                table: "Squads");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tournaments_TournamentId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TournamentId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Squads_TeamId",
                table: "Squads");
        }
    }
}
