using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasteRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_instruction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Instruction",
                table: "Recipes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "Recipes");
        }
    }
}
