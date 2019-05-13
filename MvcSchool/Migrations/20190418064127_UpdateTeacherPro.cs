using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcSchool.Migrations
{
    public partial class UpdateTeacherPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TeacherName",
                table: "Teacher",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeacherName",
                table: "Teacher",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
