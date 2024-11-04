using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFProject.Migrations
{
    /// <inheritdoc />
    public partial class WorkerTodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Tasks_CurrentTaskTaskId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Tasks_CurrentTodoTaskId",
                table: "Worker");

            migrationBuilder.RenameColumn(
                name: "CurrentTodoTaskId",
                table: "Worker",
                newName: "CurrentTodoId");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_CurrentTodoTaskId",
                table: "Worker",
                newName: "IX_Worker_CurrentTodoId");

            migrationBuilder.RenameColumn(
                name: "CurrentTaskTaskId",
                table: "Team",
                newName: "CurrentTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_CurrentTaskTaskId",
                table: "Team",
                newName: "IX_Team_CurrentTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Tasks_CurrentTaskId",
                table: "Team",
                column: "CurrentTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Tasks_CurrentTodoId",
                table: "Worker",
                column: "CurrentTodoId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Tasks_CurrentTaskId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Tasks_CurrentTodoId",
                table: "Worker");

            migrationBuilder.RenameColumn(
                name: "CurrentTodoId",
                table: "Worker",
                newName: "CurrentTodoTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_CurrentTodoId",
                table: "Worker",
                newName: "IX_Worker_CurrentTodoTaskId");

            migrationBuilder.RenameColumn(
                name: "CurrentTaskId",
                table: "Team",
                newName: "CurrentTaskTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_CurrentTaskId",
                table: "Team",
                newName: "IX_Team_CurrentTaskTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Tasks_CurrentTaskTaskId",
                table: "Team",
                column: "CurrentTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Tasks_CurrentTodoTaskId",
                table: "Worker",
                column: "CurrentTodoTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
