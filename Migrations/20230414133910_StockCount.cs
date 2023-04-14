using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab3.Migrations
{
    /// <inheritdoc />
    public partial class StockCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Product");

            migrationBuilder.AddColumn<uint>(
                name: "StockCount",
                table: "Product",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "Product");

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Product",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
