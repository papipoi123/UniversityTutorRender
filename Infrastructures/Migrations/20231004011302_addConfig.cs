using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    public partial class addConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineClasses_Students_StudentId",
                table: "OnlineClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineClasses_TeachingCourses_TeachingCourseId",
                table: "OnlineClasses");

            migrationBuilder.DropIndex(
                name: "IX_Users_AdminId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TutorId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnlineClasses",
                table: "OnlineClasses");

            migrationBuilder.RenameTable(
                name: "OnlineClasses",
                newName: "OnlineClass");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineClasses_StudentId",
                table: "OnlineClass",
                newName: "IX_OnlineClass_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineClasses_ClassCode",
                table: "OnlineClass",
                newName: "IX_OnlineClass_ClassCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnlineClass",
                table: "OnlineClass",
                columns: new[] { "TeachingCourseId", "StudentId" });

            migrationBuilder.CreateTable(
                name: "FavoriteCourse",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeachingCourseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCourse", x => new { x.TeachingCourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_FavoriteCourse_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteCourse_TeachingCourses_TeachingCourseId",
                        column: x => x.TeachingCourseId,
                        principalTable: "TeachingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdminId",
                table: "Users",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentId",
                table: "Users",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TutorId",
                table: "Users",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCourse_StudentId",
                table: "FavoriteCourse",
                column: "StudentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineClass_Students_StudentId",
                table: "OnlineClass");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineClass_TeachingCourses_TeachingCourseId",
                table: "OnlineClass");

            migrationBuilder.DropTable(
                name: "FavoriteCourse");

            migrationBuilder.DropIndex(
                name: "IX_Users_AdminId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TutorId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnlineClass",
                table: "OnlineClass");

            migrationBuilder.RenameTable(
                name: "OnlineClass",
                newName: "OnlineClasses");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineClass_StudentId",
                table: "OnlineClasses",
                newName: "IX_OnlineClasses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineClass_ClassCode",
                table: "OnlineClasses",
                newName: "IX_OnlineClasses_ClassCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnlineClasses",
                table: "OnlineClasses",
                columns: new[] { "TeachingCourseId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdminId",
                table: "Users",
                column: "AdminId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentId",
                table: "Users",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TutorId",
                table: "Users",
                column: "TutorId",
                unique: true);

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
    }
}
