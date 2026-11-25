using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LenguaLiteratura.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupToSpellingExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "SpellingExercises",
                type: "text",
                nullable: false,
                defaultValue: "children");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "SpellingExercises");
        }
    }
}
