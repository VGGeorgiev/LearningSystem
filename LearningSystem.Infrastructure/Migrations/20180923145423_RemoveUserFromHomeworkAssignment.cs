using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningSystem.Infrastructure.Migrations
{
    public partial class RemoveUserFromHomeworkAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkAssignments_Users_UserId",
                table: "HomeworkAssignments");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkAssignments_UserId",
                table: "HomeworkAssignments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HomeworkAssignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HomeworkAssignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAssignments_UserId",
                table: "HomeworkAssignments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkAssignments_Users_UserId",
                table: "HomeworkAssignments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
