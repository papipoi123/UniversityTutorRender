using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    public partial class updateConfigNA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnualTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TutorFeedbacks",
                table: "TutorFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TutorFeedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ClassCode",
                table: "OnlineClasses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TutorFeedbacks",
                table: "TutorFeedbacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "WeeklyTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeachingCourseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyTimes_TeachingCourses_TeachingCourseId",
                        column: x => x.TeachingCourseId,
                        principalTable: "TeachingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutorFeedbacks_StudentId",
                table: "TutorFeedbacks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_StudentId",
                table: "Ratings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineClasses_ClassCode",
                table: "OnlineClasses",
                column: "ClassCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimes_TeachingCourseId",
                table: "WeeklyTimes",
                column: "TeachingCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TutorFeedbacks",
                table: "TutorFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_TutorFeedbacks_StudentId",
                table: "TutorFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_StudentId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_OnlineClasses_ClassCode",
                table: "OnlineClasses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TutorFeedbacks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ratings");

            migrationBuilder.AlterColumn<string>(
                name: "ClassCode",
                table: "OnlineClasses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TutorFeedbacks",
                table: "TutorFeedbacks",
                columns: new[] { "StudentId", "TutorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                columns: new[] { "StudentId", "TeachingCourseId" });

            migrationBuilder.CreateTable(
                name: "AnnualTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeachingCourseId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualTimes_TeachingCourses_TeachingCourseId",
                        column: x => x.TeachingCourseId,
                        principalTable: "TeachingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTimes_TeachingCourseId",
                table: "AnnualTimes",
                column: "TeachingCourseId");
        }
    }
}
