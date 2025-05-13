using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fishing_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaitBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaitBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FishSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FishSpecie = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishSpecies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProvinceName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RigName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weather = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaitModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    BaitTypeId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaitModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaitModels_BaitBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "BaitBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaitModels_BaitTypes_BaitTypeId",
                        column: x => x.BaitTypeId,
                        principalTable: "BaitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dam_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DamLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DamId = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DamLocations_Dam_DamId",
                        column: x => x.DamId,
                        principalTable: "Dam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FishSpecieId = table.Column<int>(type: "integer", nullable: false),
                    RigsId = table.Column<int>(type: "integer", nullable: false),
                    DamLocationId = table.Column<int>(type: "integer", nullable: false),
                    WeatherId = table.Column<int>(type: "integer", nullable: false),
                    Temperature = table.Column<int>(type: "integer", nullable: false),
                    Day = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogModels_DamLocations_DamLocationId",
                        column: x => x.DamLocationId,
                        principalTable: "DamLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogModels_FishSpecies_FishSpecieId",
                        column: x => x.FishSpecieId,
                        principalTable: "FishSpecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogModels_Rigs_RigsId",
                        column: x => x.RigsId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogModels_Weather_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaitLogRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BaitId = table.Column<int>(type: "integer", nullable: false),
                    LogId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaitLogRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaitLogRelations_BaitModels_BaitId",
                        column: x => x.BaitId,
                        principalTable: "BaitModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaitLogRelations_LogModels_LogId",
                        column: x => x.LogId,
                        principalTable: "LogModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BaitBrands",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1, "Signature Series" },
                    { 2, "Supercast" },
                    { 3, "Jumbo" },
                    { 4, "Supercast" },
                    { 5, "Boulyn" },
                    { 6, "Fish" },
                    { 7, "Magic Baits" },
                    { 8, "Conoflex" },
                    { 9, "Trucella" },
                    { 10, "Self" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaitLogRelations_BaitId",
                table: "BaitLogRelations",
                column: "BaitId");

            migrationBuilder.CreateIndex(
                name: "IX_BaitLogRelations_LogId",
                table: "BaitLogRelations",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_BaitModels_BaitTypeId",
                table: "BaitModels",
                column: "BaitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaitModels_BrandId",
                table: "BaitModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Dam_ProvinceId",
                table: "Dam",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_DamLocations_DamId",
                table: "DamLocations",
                column: "DamId");

            migrationBuilder.CreateIndex(
                name: "IX_LogModels_DamLocationId",
                table: "LogModels",
                column: "DamLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LogModels_FishSpecieId",
                table: "LogModels",
                column: "FishSpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_LogModels_RigsId",
                table: "LogModels",
                column: "RigsId");

            migrationBuilder.CreateIndex(
                name: "IX_LogModels_WeatherId",
                table: "LogModels",
                column: "WeatherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaitLogRelations");

            migrationBuilder.DropTable(
                name: "BaitModels");

            migrationBuilder.DropTable(
                name: "LogModels");

            migrationBuilder.DropTable(
                name: "BaitBrands");

            migrationBuilder.DropTable(
                name: "BaitTypes");

            migrationBuilder.DropTable(
                name: "DamLocations");

            migrationBuilder.DropTable(
                name: "FishSpecies");

            migrationBuilder.DropTable(
                name: "Rigs");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Dam");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
