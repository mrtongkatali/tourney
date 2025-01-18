using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RenameTournamentStageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TournamentStage_tournaments_tournament_id",
                table: "TournamentStage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentStage",
                table: "TournamentStage");

            migrationBuilder.RenameTable(
                name: "TournamentStage",
                newName: "tournament_stages");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentStage_tournament_id",
                table: "tournament_stages",
                newName: "IX_tournament_stages_tournament_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tournament_stages",
                table: "tournament_stages",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tournament_stages_tournaments_tournament_id",
                table: "tournament_stages",
                column: "tournament_id",
                principalTable: "tournaments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tournament_stages_tournaments_tournament_id",
                table: "tournament_stages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tournament_stages",
                table: "tournament_stages");

            migrationBuilder.RenameTable(
                name: "tournament_stages",
                newName: "TournamentStage");

            migrationBuilder.RenameIndex(
                name: "IX_tournament_stages_tournament_id",
                table: "TournamentStage",
                newName: "IX_TournamentStage_tournament_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentStage",
                table: "TournamentStage",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentStage_tournaments_tournament_id",
                table: "TournamentStage",
                column: "tournament_id",
                principalTable: "tournaments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
