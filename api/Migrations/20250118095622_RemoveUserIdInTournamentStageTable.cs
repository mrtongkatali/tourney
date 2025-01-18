using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserIdInTournamentStageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TournamentStage_tournaments_user_id",
                table: "TournamentStage");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentStage_users_UserId1",
                table: "TournamentStage");

            migrationBuilder.DropIndex(
                name: "IX_TournamentStage_user_id",
                table: "TournamentStage");

            migrationBuilder.DropIndex(
                name: "IX_TournamentStage_UserId1",
                table: "TournamentStage");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TournamentStage");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "TournamentStage");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentStage_tournament_id",
                table: "TournamentStage",
                column: "tournament_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentStage_tournaments_tournament_id",
                table: "TournamentStage",
                column: "tournament_id",
                principalTable: "tournaments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TournamentStage_tournaments_tournament_id",
                table: "TournamentStage");

            migrationBuilder.DropIndex(
                name: "IX_TournamentStage_tournament_id",
                table: "TournamentStage");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "TournamentStage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "TournamentStage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TournamentStage_user_id",
                table: "TournamentStage",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentStage_UserId1",
                table: "TournamentStage",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentStage_tournaments_user_id",
                table: "TournamentStage",
                column: "user_id",
                principalTable: "tournaments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentStage_users_UserId1",
                table: "TournamentStage",
                column: "UserId1",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
