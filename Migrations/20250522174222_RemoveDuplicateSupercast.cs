using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fishing_API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDuplicateSupercast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BaitBrands",
                keyColumn: "Id",
                keyValue: 4,
                column: "Brand",
                value: "Zoom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BaitBrands",
                keyColumn: "Id",
                keyValue: 4,
                column: "Brand",
                value: "Supercast");
        }
    }
}
