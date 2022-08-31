using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationPortal.Infrastructure.DB.Migrations
{
    public partial class FixNameForUserCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbUserCourse_Courses_CourseId",
                table: "DbUserCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_DbUserCourse_Users_UserId",
                table: "DbUserCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbUserCourse",
                table: "DbUserCourse");

            migrationBuilder.RenameTable(
                name: "DbUserCourse",
                newName: "UserCourses");

            migrationBuilder.RenameIndex(
                name: "IX_DbUserCourse_CourseId",
                table: "UserCourses",
                newName: "IX_UserCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourses",
                table: "UserCourses",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Users_UserId",
                table: "UserCourses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Users_UserId",
                table: "UserCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourses",
                table: "UserCourses");

            migrationBuilder.RenameTable(
                name: "UserCourses",
                newName: "DbUserCourse");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourses_CourseId",
                table: "DbUserCourse",
                newName: "IX_DbUserCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbUserCourse",
                table: "DbUserCourse",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DbUserCourse_Courses_CourseId",
                table: "DbUserCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbUserCourse_Users_UserId",
                table: "DbUserCourse",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
