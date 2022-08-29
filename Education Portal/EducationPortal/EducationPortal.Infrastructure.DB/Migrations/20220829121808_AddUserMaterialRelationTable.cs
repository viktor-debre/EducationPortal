using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationPortal.Infrastructure.DB.Migrations
{
    public partial class AddUserMaterialRelationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMaterials",
                columns: table => new
                {
                    MaterialsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaterials", x => new { x.MaterialsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserMaterials_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMaterials_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMaterials_UsersId",
                table: "UserMaterials",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMaterials");
        }
    }
}
