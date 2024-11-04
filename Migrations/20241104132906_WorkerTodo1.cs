using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFProject.Migrations
{
    /// <inheritdoc />
    public partial class WorkerTodo1 : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "CurrentTodoTaskId",
                table: "Worker",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentTaskTaskId",
                table: "Team",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Tasks_CurrentTaskTaskId",
                table: "Team",
                column: "CurrentTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Tasks_CurrentTodoTaskId",
                table: "Worker",
                column: "CurrentTodoTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Tasks_CurrentTaskTaskId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Tasks_CurrentTodoTaskId",
                table: "Worker");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentTodoTaskId",
                table: "Worker",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentTaskTaskId",
                table: "Team",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
