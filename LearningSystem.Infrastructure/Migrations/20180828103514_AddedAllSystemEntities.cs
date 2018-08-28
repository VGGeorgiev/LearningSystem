using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningSystem.Infrastructure.Migrations
{
    public partial class AddedAllSystemEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Season_SeasonId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Users_UserId",
                table: "Application");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Season",
                table: "Season");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "Season",
                newName: "Seasons");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_Application_UserId",
                table: "Applications",
                newName: "IX_Applications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_SeasonId",
                table: "Applications",
                newName: "IX_Applications_SeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Credits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Rating = table.Column<short>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ReporterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false),
                    VideoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersInCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Grade = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesInSemesters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    SemesterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesInSemesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesInSemesters_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesInSemesters_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LectureId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkAssignments_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeworkAssignments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LectureId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    File = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkSubmissions_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeworkSubmissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkEvaluations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Valuation = table.Column<int>(nullable: false),
                    HomeworkSubmissionId = table.Column<int>(nullable: false),
                    EvaluatedById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkEvaluations_Users_EvaluatedById",
                        column: x => x.EvaluatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeworkEvaluations_HomeworkSubmissions_HomeworkSubmissionId",
                        column: x => x.HomeworkSubmissionId,
                        principalTable: "HomeworkSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInSemesters_CourseId",
                table: "CoursesInSemesters",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInSemesters_SemesterId",
                table: "CoursesInSemesters",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ReporterId",
                table: "Feedbacks",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAssignments_LectureId",
                table: "HomeworkAssignments",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAssignments_UserId",
                table: "HomeworkAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkEvaluations_EvaluatedById",
                table: "HomeworkEvaluations",
                column: "EvaluatedById");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkEvaluations_HomeworkSubmissionId",
                table: "HomeworkEvaluations",
                column: "HomeworkSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmissions_LectureId",
                table: "HomeworkSubmissions",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmissions_UserId",
                table: "HomeworkSubmissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInCourses_CourseId",
                table: "UsersInCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInCourses_UserId",
                table: "UsersInCourses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Seasons_SeasonId",
                table: "Applications",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Seasons_SeasonId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "CoursesInSemesters");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "HomeworkAssignments");

            migrationBuilder.DropTable(
                name: "HomeworkEvaluations");

            migrationBuilder.DropTable(
                name: "UsersInCourses");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "HomeworkSubmissions");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Seasons",
                newName: "Season");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_UserId",
                table: "Application",
                newName: "IX_Application_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_SeasonId",
                table: "Application",
                newName: "IX_Application_SeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Season",
                table: "Season",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Season_SeasonId",
                table: "Application",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Users_UserId",
                table: "Application",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
