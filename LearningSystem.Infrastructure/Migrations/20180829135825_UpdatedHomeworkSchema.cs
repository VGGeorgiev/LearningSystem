using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningSystem.Infrastructure.Migrations
{
    public partial class UpdatedHomeworkSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkAssignments_Lectures_LectureId",
                table: "HomeworkAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmissions_Lectures_LectureId",
                table: "HomeworkSubmissions");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "HomeworkSubmissions",
                newName: "HomeworkAssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeworkSubmissions_LectureId",
                table: "HomeworkSubmissions",
                newName: "IX_HomeworkSubmissions_HomeworkAssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkAssignments_Lectures_LectureId",
                table: "HomeworkAssignments",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmissions_HomeworkAssignments_HomeworkAssignmentId",
                table: "HomeworkSubmissions",
                column: "HomeworkAssignmentId",
                principalTable: "HomeworkAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkAssignments_Lectures_LectureId",
                table: "HomeworkAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmissions_HomeworkAssignments_HomeworkAssignmentId",
                table: "HomeworkSubmissions");

            migrationBuilder.RenameColumn(
                name: "HomeworkAssignmentId",
                table: "HomeworkSubmissions",
                newName: "LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeworkSubmissions_HomeworkAssignmentId",
                table: "HomeworkSubmissions",
                newName: "IX_HomeworkSubmissions_LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkAssignments_Lectures_LectureId",
                table: "HomeworkAssignments",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmissions_Lectures_LectureId",
                table: "HomeworkSubmissions",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
