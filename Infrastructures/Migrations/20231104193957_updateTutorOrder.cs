using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    public partial class updateTutorOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Students_StudentId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TutorId",
                table: "Orders",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Students_StudentId",
                table: "Orders",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tutors_TutorId",
                table: "Orders",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Students_StudentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tutors_TutorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TutorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Students_StudentId",
                table: "Orders",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
