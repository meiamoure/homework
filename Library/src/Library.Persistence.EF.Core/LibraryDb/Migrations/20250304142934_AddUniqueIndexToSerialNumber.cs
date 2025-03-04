using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistence.EF.Core.LibraryDb.Migrations;

/// <inheritdoc />
public partial class AddUniqueIndexToSerialNumber : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateIndex(
            name: "IX_Books_SerialNumber",
            schema: "library",
            table: "Books",
            column: "SerialNumber",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_Books_SerialNumber",
            schema: "library",
            table: "Books");
    }
}
