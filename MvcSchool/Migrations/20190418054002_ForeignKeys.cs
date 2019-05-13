using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcSchool.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StuMajor",
                table: "Student",
                newName: "MajorName");

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "Teacher",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MajorName",
                table: "Teacher",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MajorName",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Course",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_MajorId",
                table: "Teacher",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_MajorId",
                table: "Student",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_MajorId",
                table: "Course",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherId",
                table: "Course",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Major_MajorId",
                table: "Course",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "MajorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teacher_TeacherId",
                table: "Course",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Major_MajorId",
                table: "Student",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "MajorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Major_MajorId",
                table: "Teacher",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "MajorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Major_MajorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teacher_TeacherId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Major_MajorId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Major_MajorId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_MajorId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Student_MajorId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Course_MajorId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_TeacherId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "MajorName",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "MajorName",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "MajorName",
                table: "Student",
                newName: "StuMajor");
        }
    }
}
