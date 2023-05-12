using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBRecipes.API.Migrations
{
    public partial class RecipeImageStoredAsString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Recipes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Leves" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Főétel" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Köret, főzelék" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Desszert" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Torta" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Saláta" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Befőzés" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Egyéb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Recipes",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
