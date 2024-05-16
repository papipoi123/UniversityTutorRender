using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    public partial class updateTeachingCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvgRating",
                table: "TeachingCourses",
                newName: "RatingStar");

            migrationBuilder.AddColumn<string>(
                name: "CourseImage",
                table: "TeachingCourses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseImage",
                table: "TeachingCourses");

            migrationBuilder.RenameColumn(
                name: "RatingStar",
                table: "TeachingCourses",
                newName: "AvgRating");
        }
    }
}
