using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcSchool.Migrations
{
    public partial class userId_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CourseDate",
                table: "Course",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Student");

            migrationBuilder.AlterColumn<string>(
                name: "CourseDate",
                table: "Course",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
