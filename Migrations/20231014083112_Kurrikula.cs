using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShkollaA1.Migrations
{
    public partial class Kurrikula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurriculumId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Curriculum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weeks = table.Column<short>(type: "smallint", nullable: false),
                    Hours = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CurriculumId",
                table: "Subjects",
                column: "CurriculumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Curriculum_CurriculumId",
                table: "Subjects",
                column: "CurriculumId",
                principalTable: "Curriculum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Curriculum_CurriculumId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Curriculum");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_CurriculumId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CurriculumId",
                table: "Subjects");
        }
    }
}
