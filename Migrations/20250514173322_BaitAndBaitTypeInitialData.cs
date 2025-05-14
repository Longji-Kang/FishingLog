using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fishing_API.Migrations
{
    /// <inheritdoc />
    public partial class BaitAndBaitTypeInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaitLogRelations_BaitModels_BaitId",
                table: "BaitLogRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_BaitModels_BaitBrands_BrandId",
                table: "BaitModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BaitModels_BaitTypes_BaitTypeId",
                table: "BaitModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaitModels",
                table: "BaitModels");

            migrationBuilder.RenameTable(
                name: "BaitModels",
                newName: "Baits");

            migrationBuilder.RenameIndex(
                name: "IX_BaitModels_BrandId",
                table: "Baits",
                newName: "IX_Baits_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BaitModels_BaitTypeId",
                table: "Baits",
                newName: "IX_Baits_BaitTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baits",
                table: "Baits",
                column: "Id");

            migrationBuilder.InsertData(
                table: "BaitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Oozing Floatie" },
                    { 2, "Hard Floatie" },
                    { 3, "Fluke" },
                    { 4, "Trick Worm" },
                    { 5, "Crank Bait" },
                    { 6, "Dip" },
                    { 7, "Ground Feed" },
                    { 8, "Mielies" },
                    { 9, "Bullets" },
                    { 10, "Dough" },
                    { 11, "Feed Mix" },
                    { 12, "Live" }
                });

            migrationBuilder.InsertData(
                table: "Baits",
                columns: new[] { "Id", "BaitTypeId", "BrandId", "Description" },
                values: new object[,]
                {
                    { 1, 7, 5, "Boulyn Kolletjie" },
                    { 2, 2, 2, "Perdeby" },
                    { 3, 2, 2, "Plain White" },
                    { 4, 2, 2, "Plain Yellow" },
                    { 5, 1, 2, "Pandemonium" },
                    { 6, 1, 2, "Fire and Ice" },
                    { 7, 1, 2, "Garlic" },
                    { 8, 1, 6, "Garlic" },
                    { 9, 1, 6, "Legend" },
                    { 10, 1, 6, "Sniper" },
                    { 11, 1, 6, "Banjo" },
                    { 12, 1, 3, "Banana" },
                    { 13, 1, 3, "Perdeby" },
                    { 14, 1, 7, "HLX" },
                    { 15, 1, 7, "Alm X" },
                    { 16, 2, 8, "Chop Chop" },
                    { 17, 1, 7, "Alm X" },
                    { 18, 1, 1, "Level 5" },
                    { 19, 1, 1, "SWG" },
                    { 20, 1, 1, "F2 Fifty" },
                    { 21, 1, 1, "Tjop Tjop" },
                    { 22, 1, 1, "DKW" },
                    { 23, 2, 1, "Banlick" },
                    { 24, 2, 1, "Garlic" },
                    { 25, 9, 1, "Level 5" },
                    { 26, 9, 6, "Perdeby" },
                    { 27, 8, 2, "Tutti Frutti" },
                    { 28, 8, 2, "Gumtree" },
                    { 29, 8, 2, "Vaaldam" },
                    { 30, 8, 2, "Caramel" },
                    { 31, 6, 6, "Honey High Attract Liquid" },
                    { 32, 6, 2, "Stinkvoete" },
                    { 33, 6, 2, "Schalas" },
                    { 34, 6, 2, "Honey Glow" },
                    { 35, 6, 2, "Schalas" },
                    { 36, 6, 2, "Tjop Tjop" },
                    { 37, 6, 2, "Almond S" },
                    { 38, 6, 2, "Kiana" },
                    { 39, 6, 2, "Gumtree" },
                    { 40, 6, 2, "Perdeby" },
                    { 41, 6, 2, "Banji" },
                    { 42, 6, 2, "Legend" },
                    { 43, 6, 2, "FX" },
                    { 44, 6, 9, "Hot Honey" },
                    { 45, 6, 1, "Turbo Garlic" },
                    { 46, 6, 1, "Juliass" },
                    { 47, 6, 1, "Plakker" },
                    { 48, 6, 1, "Agmed" },
                    { 49, 6, 1, "Hoekom Bloekom" },
                    { 50, 6, 1, "HKGK" },
                    { 51, 6, 1, "Raptor" },
                    { 52, 11, 1, "Level 5 Feedmix" },
                    { 53, 12, 10, "African Night Crawlers" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BaitLogRelations_Baits_BaitId",
                table: "BaitLogRelations",
                column: "BaitId",
                principalTable: "Baits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baits_BaitBrands_BrandId",
                table: "Baits",
                column: "BrandId",
                principalTable: "BaitBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baits_BaitTypes_BaitTypeId",
                table: "Baits",
                column: "BaitTypeId",
                principalTable: "BaitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaitLogRelations_Baits_BaitId",
                table: "BaitLogRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_Baits_BaitBrands_BrandId",
                table: "Baits");

            migrationBuilder.DropForeignKey(
                name: "FK_Baits_BaitTypes_BaitTypeId",
                table: "Baits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baits",
                table: "Baits");

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Baits",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BaitTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.RenameTable(
                name: "Baits",
                newName: "BaitModels");

            migrationBuilder.RenameIndex(
                name: "IX_Baits_BrandId",
                table: "BaitModels",
                newName: "IX_BaitModels_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Baits_BaitTypeId",
                table: "BaitModels",
                newName: "IX_BaitModels_BaitTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaitModels",
                table: "BaitModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaitLogRelations_BaitModels_BaitId",
                table: "BaitLogRelations",
                column: "BaitId",
                principalTable: "BaitModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaitModels_BaitBrands_BrandId",
                table: "BaitModels",
                column: "BrandId",
                principalTable: "BaitBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaitModels_BaitTypes_BaitTypeId",
                table: "BaitModels",
                column: "BaitTypeId",
                principalTable: "BaitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
