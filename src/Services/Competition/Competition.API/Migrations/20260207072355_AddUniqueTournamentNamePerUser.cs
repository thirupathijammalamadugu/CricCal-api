using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Competition.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueTournamentNamePerUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_Name_CreatedByUserId",
                table: "Tournaments",
                columns: new[] { "Name", "CreatedByUserId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tournaments_Name_CreatedByUserId",
                table: "Tournaments");
        }
    }
}
