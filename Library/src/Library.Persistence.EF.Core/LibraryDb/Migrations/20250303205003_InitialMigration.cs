using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistence.EF.Core.LibraryDb.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "library");

        migrationBuilder.CreateTable(
            name: "Authors",
            schema: "library",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Authors", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Books",
            schema: "library",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                SerialNumber = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Books", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AuthorBooks",
            schema: "library",
            columns: table => new
            {
                BookId = table.Column<Guid>(type: "uuid", nullable: false),
                AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AuthorBooks", x => new { x.BookId, x.AuthorId });
                table.ForeignKey(
                    name: "FK_AuthorBooks_Authors_AuthorId",
                    column: x => x.AuthorId,
                    principalSchema: "library",
                    principalTable: "Authors",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AuthorBooks_Books_BookId",
                    column: x => x.BookId,
                    principalSchema: "library",
                    principalTable: "Books",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_AuthorBooks_AuthorId",
            schema: "library",
            table: "AuthorBooks",
            column: "AuthorId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AuthorBooks",
            schema: "library");

        migrationBuilder.DropTable(
            name: "Authors",
            schema: "library");

        migrationBuilder.DropTable(
            name: "Books",
            schema: "library");
    }
}
