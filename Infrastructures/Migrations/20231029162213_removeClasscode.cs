using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    public partial class removeClasscode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OnlineClasses_ClassCode",
                table: "OnlineClasses");

            migrationBuilder.DropColumn(
                name: "ClassCode",
                table: "OnlineClasses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassCode",
                table: "OnlineClasses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineClasses_ClassCode",
                table: "OnlineClasses",
                column: "ClassCode",
                unique: true);
        }
    }
}
