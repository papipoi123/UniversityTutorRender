using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    public partial class UpdateRealationshipBetweenTeachingCourseAndCourMajorAndAddUniversity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMajors_TeachingCourses_TeachingCourseId",
                table: "CourseMajors");

            migrationBuilder.DropIndex(
                name: "IX_CourseMajors_TeachingCourseId",
                table: "CourseMajors");

            migrationBuilder.DropColumn(
                name: "TeachingCourseId",
                table: "CourseMajors");

            migrationBuilder.AddColumn<int>(
                name: "CourseMajorId",
                table: "TeachingCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "TeachingCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityArea = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeachingCourses_CourseMajorId",
                table: "TeachingCourses",
                column: "CourseMajorId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingCourses_UniversityId",
                table: "TeachingCourses",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachingCourses_CourseMajors_CourseMajorId",
                table: "TeachingCourses",
                column: "CourseMajorId",
                principalTable: "CourseMajors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachingCourses_University_UniversityId",
                table: "TeachingCourses",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeachingCourses_CourseMajors_CourseMajorId",
                table: "TeachingCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachingCourses_University_UniversityId",
                table: "TeachingCourses");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropIndex(
                name: "IX_TeachingCourses_CourseMajorId",
                table: "TeachingCourses");

            migrationBuilder.DropIndex(
                name: "IX_TeachingCourses_UniversityId",
                table: "TeachingCourses");

            migrationBuilder.DropColumn(
                name: "CourseMajorId",
                table: "TeachingCourses");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "TeachingCourses");

            migrationBuilder.AddColumn<int>(
                name: "TeachingCourseId",
                table: "CourseMajors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseMajors_TeachingCourseId",
                table: "CourseMajors",
                column: "TeachingCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMajors_TeachingCourses_TeachingCourseId",
                table: "CourseMajors",
                column: "TeachingCourseId",
                principalTable: "TeachingCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
