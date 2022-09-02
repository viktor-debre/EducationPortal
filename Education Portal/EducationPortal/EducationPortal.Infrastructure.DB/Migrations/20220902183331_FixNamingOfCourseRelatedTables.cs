using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationPortal.Infrastructure.DB.Migrations
{
    public partial class FixNamingOfCourseRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbCourseDbMaterial_Courses_CoursesId",
                table: "DbCourseDbMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_DbCourseDbMaterial_Materials_MaterialsId",
                table: "DbCourseDbMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_DbCourseDbSkill_Courses_CoursesId",
                table: "DbCourseDbSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_DbCourseDbSkill_Skills_SkillsId",
                table: "DbCourseDbSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbCourseDbSkill",
                table: "DbCourseDbSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbCourseDbMaterial",
                table: "DbCourseDbMaterial");

            migrationBuilder.RenameTable(
                name: "DbCourseDbSkill",
                newName: "CourseSkill");

            migrationBuilder.RenameTable(
                name: "DbCourseDbMaterial",
                newName: "CourseMaterials");

            migrationBuilder.RenameIndex(
                name: "IX_DbCourseDbSkill_SkillsId",
                table: "CourseSkill",
                newName: "IX_CourseSkill_SkillsId");

            migrationBuilder.RenameIndex(
                name: "IX_DbCourseDbMaterial_MaterialsId",
                table: "CourseMaterials",
                newName: "IX_CourseMaterials_MaterialsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSkill",
                table: "CourseSkill",
                columns: new[] { "CoursesId", "SkillsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseMaterials",
                table: "CourseMaterials",
                columns: new[] { "CoursesId", "MaterialsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMaterials_Courses_CoursesId",
                table: "CourseMaterials",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMaterials_Materials_MaterialsId",
                table: "CourseMaterials",
                column: "MaterialsId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSkill_Courses_CoursesId",
                table: "CourseSkill",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSkill_Skills_SkillsId",
                table: "CourseSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMaterials_Courses_CoursesId",
                table: "CourseMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseMaterials_Materials_MaterialsId",
                table: "CourseMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSkill_Courses_CoursesId",
                table: "CourseSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSkill_Skills_SkillsId",
                table: "CourseSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSkill",
                table: "CourseSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseMaterials",
                table: "CourseMaterials");

            migrationBuilder.RenameTable(
                name: "CourseSkill",
                newName: "DbCourseDbSkill");

            migrationBuilder.RenameTable(
                name: "CourseMaterials",
                newName: "DbCourseDbMaterial");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSkill_SkillsId",
                table: "DbCourseDbSkill",
                newName: "IX_DbCourseDbSkill_SkillsId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseMaterials_MaterialsId",
                table: "DbCourseDbMaterial",
                newName: "IX_DbCourseDbMaterial_MaterialsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbCourseDbSkill",
                table: "DbCourseDbSkill",
                columns: new[] { "CoursesId", "SkillsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbCourseDbMaterial",
                table: "DbCourseDbMaterial",
                columns: new[] { "CoursesId", "MaterialsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DbCourseDbMaterial_Courses_CoursesId",
                table: "DbCourseDbMaterial",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbCourseDbMaterial_Materials_MaterialsId",
                table: "DbCourseDbMaterial",
                column: "MaterialsId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbCourseDbSkill_Courses_CoursesId",
                table: "DbCourseDbSkill",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbCourseDbSkill_Skills_SkillsId",
                table: "DbCourseDbSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
