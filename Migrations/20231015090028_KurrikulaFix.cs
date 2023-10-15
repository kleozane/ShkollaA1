using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShkollaA1.Migrations
{
    public partial class KurrikulaFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Curriculum_CurriculumId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curriculum",
                table: "Curriculum");

            migrationBuilder.RenameTable(
                name: "Curriculum",
                newName: "Curriculums");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curriculums",
                table: "Curriculums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Curriculums_CurriculumId",
                table: "Subjects",
                column: "CurriculumId",
                principalTable: "Curriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Curriculums_CurriculumId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curriculums",
                table: "Curriculums");

            migrationBuilder.RenameTable(
                name: "Curriculums",
                newName: "Curriculum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curriculum",
                table: "Curriculum",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Curriculum_CurriculumId",
                table: "Subjects",
                column: "CurriculumId",
                principalTable: "Curriculum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
