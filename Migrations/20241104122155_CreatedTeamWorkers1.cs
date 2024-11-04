using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFProject.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTeamWorkers1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TeamWorker_WorkerId",
                table: "TeamWorker",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorker_Team_TeamId",
                table: "TeamWorker",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorker_Worker_WorkerId",
                table: "TeamWorker",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorker_Team_TeamId",
                table: "TeamWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorker_Worker_WorkerId",
                table: "TeamWorker");

            migrationBuilder.DropIndex(
                name: "IX_TeamWorker_WorkerId",
                table: "TeamWorker");
        }
    }
}
