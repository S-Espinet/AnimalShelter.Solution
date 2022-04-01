using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
#pragma warning disable CS1591
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Gender", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 2, "Female", "Link", "Cat" },
                    { 2, 2, "Female", "Zelda", "Cat" },
                    { 3, 3, "Male", "Ganon", "Cat" },
                    { 4, 4, "Female", "Merry", "Dog" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);
        }
    }
#pragma warning restore CS1591
}
