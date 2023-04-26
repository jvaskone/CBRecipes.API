using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBRecipes.API.Migrations
{
    public partial class CBRecipesDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "Ingredients", "Instructions", "Name" },
                values: new object[] { 1, 1, "To be added..", "To be added...", "Húsleves" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "Ingredients", "Instructions", "Name" },
                values: new object[] { 2, 2, "To be added...", "To be added...", "Csirkepaprikás" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
