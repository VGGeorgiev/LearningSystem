using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningSystem.Infrastructure.Migrations
{
    public partial class AddedHomeworkAssignmentContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "HomeworkAssignments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "HomeworkAssignments");
        }
    }
}
