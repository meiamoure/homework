using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hmw17.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionAndMerchant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "transactions",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Merchant",
                schema: "transactions",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "transactions",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Merchant",
                schema: "transactions",
                table: "Transactions");
        }
    }
}
