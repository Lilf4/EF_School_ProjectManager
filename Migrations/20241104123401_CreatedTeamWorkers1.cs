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
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: true),
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentTaskTaskId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Tasks_CurrentTaskTaskId",
                        column: x => x.CurrentTaskTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    TodoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    TaskId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.TodoId);
                    table.ForeignKey(
                        name: "FK_Todos_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentTodoTaskId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.WorkerId);
                    table.ForeignKey(
                        name: "FK_Worker_Tasks_CurrentTodoTaskId",
                        column: x => x.CurrentTodoTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamWorker",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamWorker", x => new { x.TeamId, x.WorkerId });
                    table.ForeignKey(
                        name: "FK_TeamWorker_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamWorker_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamWorker1",
                columns: table => new
                {
                    TeamsTeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkersWorkerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamWorker1", x => new { x.TeamsTeamId, x.WorkersWorkerId });
                    table.ForeignKey(
                        name: "FK_TeamWorker1_Team_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamWorker1_Worker_WorkersWorkerId",
                        column: x => x.WorkersWorkerId,
                        principalTable: "Worker",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TeamId",
                table: "Tasks",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WorkerId",
                table: "Tasks",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CurrentTaskTaskId",
                table: "Team",
                column: "CurrentTaskTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamWorker_WorkerId",
                table: "TeamWorker",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamWorker1_WorkersWorkerId",
                table: "TeamWorker1",
                column: "WorkersWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_TaskId",
                table: "Todos",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_CurrentTodoTaskId",
                table: "Worker",
                column: "CurrentTodoTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Team_TeamId",
                table: "Tasks",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Worker_WorkerId",
                table: "Tasks",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Team_TeamId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Worker_WorkerId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TeamWorker");

            migrationBuilder.DropTable(
                name: "TeamWorker1");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
