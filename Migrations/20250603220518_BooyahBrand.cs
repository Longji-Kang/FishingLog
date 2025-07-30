using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fishing_API.Migrations
{
    /// <inheritdoc />
    public partial class BooyahBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BaitBrands",
                columns: new[] { "Id", "Brand" },
                values: new object[] { 11, "Booyah" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BaitBrands",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
