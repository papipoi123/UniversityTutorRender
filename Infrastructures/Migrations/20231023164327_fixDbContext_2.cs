using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    public partial class fixDbContext_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCourse_Students_StudentId",
                table: "FavoriteCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCourse_TeachingCourses_TeachingCourseId",
                table: "FavoriteCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineClass_Students_StudentId",
                table: "OnlineClass");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineClass_TeachingCourses_TeachingCourseId",
                table: "OnlineClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnlineClass",
                table: "OnlineClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteCourse",
                table: "FavoriteCourse");

            migrationBuilder.RenameTable(
                name: "OnlineClass",
                newName: "OnlineClasses");

            migrationBuilder.RenameTable(
                name: "FavoriteCourse",
                newName: "FavoriteCourses");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineClass_StudentId",
                table: "OnlineClasses",
                newName: "IX_OnlineClasses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineClass_ClassCode",
                table: "OnlineClasses",
                newName: "IX_OnlineClasses_ClassCode");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteCourse_StudentId",
                table: "FavoriteCourses",
                newName: "IX_FavoriteCourses_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnlineClasses",
                table: "OnlineClasses",
                columns: new[] { "TeachingCourseId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteCourses",
                table: "FavoriteCourses",
                columns: new[] { "TeachingCourseId", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCourses_Students_StudentId",
                table: "FavoriteCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCourses_TeachingCourses_TeachingCourseId",
                table: "FavoriteCourses",
                column: "TeachingCourseId",
                principalTable: "TeachingCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineClasses_Students_StudentId",
                table: "OnlineClasses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineClasses_TeachingCourses_TeachingCourseId",
                table: "OnlineClasses",
                column: "TeachingCourseId",
                principalTable: "TeachingCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCourses_Students_StudentId",
                table: "FavoriteCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCourses_TeachingCourses_TeachingCourseId",
                table: "FavoriteCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineClasses_Students_StudentId",
                table: "OnlineClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineClasses_TeachingCourses_TeachingCourseId",
                table: "OnlineClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnlineClasses",
                table: "OnlineClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteCourses",
                table: "FavoriteCourses");

            migrationBuilder.RenameTable(
                name: "OnlineClasses",
                newName: "OnlineClass");

            migrationBuilder.RenameTable(
                name: "FavoriteCourses",
                newName: "FavoriteCourse");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineClasses_StudentId",
                table: "OnlineClass",
                newName: "IX_OnlineClass_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineClasses_ClassCode",
                table: "OnlineClass",
                newName: "IX_OnlineClass_ClassCode");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteCourses_StudentId",
                table: "FavoriteCourse",
                newName: "IX_FavoriteCourse_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnlineClass",
                table: "OnlineClass",
                columns: new[] { "TeachingCourseId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteCourse",
                table: "FavoriteCourse",
                columns: new[] { "TeachingCourseId", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCourse_Students_StudentId",
                table: "FavoriteCourse",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCourse_TeachingCourses_TeachingCourseId",
                table: "FavoriteCourse",
                column: "TeachingCourseId",
                principalTable: "TeachingCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineClass_Students_StudentId",
                table: "OnlineClass",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineClass_TeachingCourses_TeachingCourseId",
                table: "OnlineClass",
                column: "TeachingCourseId",
                principalTable: "TeachingCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
