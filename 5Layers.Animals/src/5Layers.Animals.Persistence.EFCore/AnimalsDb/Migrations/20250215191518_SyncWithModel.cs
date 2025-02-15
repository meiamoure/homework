using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5Layers.Animals.Persistence.EFCore.AnimalsDb.Migrations
{
    /// <inheritdoc />
    public partial class SyncWithModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Animals");

            migrationBuilder.RenameTable(
                name: "Owners",
                schema: "animals",
                newName: "Owners",
                newSchema: "Animals");

            migrationBuilder.RenameTable(
                name: "AnimalsOwners",
                schema: "animals",
                newName: "AnimalsOwners",
                newSchema: "Animals");

            migrationBuilder.RenameTable(
                name: "Animals",
                schema: "animals",
                newName: "Animals",
                newSchema: "Animals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "animals");

            migrationBuilder.RenameTable(
                name: "Owners",
                schema: "Animals",
                newName: "Owners",
                newSchema: "animals");

            migrationBuilder.RenameTable(
                name: "AnimalsOwners",
                schema: "Animals",
                newName: "AnimalsOwners",
                newSchema: "animals");

            migrationBuilder.RenameTable(
                name: "Animals",
                schema: "Animals",
                newName: "Animals",
                newSchema: "animals");
        }
    }
}
