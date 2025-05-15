using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fishing_API.Migrations
{
    /// <inheritdoc />
    public partial class FixNamingOfLogsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaitLogRelations_LogModels_LogId",
                table: "BaitLogRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_LogModels_DamLocations_DamLocationId",
                table: "LogModels");

            migrationBuilder.DropForeignKey(
                name: "FK_LogModels_FishSpecies_FishSpecieId",
                table: "LogModels");

            migrationBuilder.DropForeignKey(
                name: "FK_LogModels_Rigs_RigsId",
                table: "LogModels");

            migrationBuilder.DropForeignKey(
                name: "FK_LogModels_Weather_WeatherId",
                table: "LogModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogModels",
                table: "LogModels");

            migrationBuilder.RenameTable(
                name: "LogModels",
                newName: "Logs");

            migrationBuilder.RenameIndex(
                name: "IX_LogModels_WeatherId",
                table: "Logs",
                newName: "IX_Logs_WeatherId");

            migrationBuilder.RenameIndex(
                name: "IX_LogModels_RigsId",
                table: "Logs",
                newName: "IX_Logs_RigsId");

            migrationBuilder.RenameIndex(
                name: "IX_LogModels_FishSpecieId",
                table: "Logs",
                newName: "IX_Logs_FishSpecieId");

            migrationBuilder.RenameIndex(
                name: "IX_LogModels_DamLocationId",
                table: "Logs",
                newName: "IX_Logs_DamLocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaitLogRelations_Logs_LogId",
                table: "BaitLogRelations",
                column: "LogId",
                principalTable: "Logs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_DamLocations_DamLocationId",
                table: "Logs",
                column: "DamLocationId",
                principalTable: "DamLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_FishSpecies_FishSpecieId",
                table: "Logs",
                column: "FishSpecieId",
                principalTable: "FishSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Rigs_RigsId",
                table: "Logs",
                column: "RigsId",
                principalTable: "Rigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Weather_WeatherId",
                table: "Logs",
                column: "WeatherId",
                principalTable: "Weather",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaitLogRelations_Logs_LogId",
                table: "BaitLogRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_DamLocations_DamLocationId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_FishSpecies_FishSpecieId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Rigs_RigsId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Weather_WeatherId",
                table: "Logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "LogModels");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_WeatherId",
                table: "LogModels",
                newName: "IX_LogModels_WeatherId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_RigsId",
                table: "LogModels",
                newName: "IX_LogModels_RigsId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_FishSpecieId",
                table: "LogModels",
                newName: "IX_LogModels_FishSpecieId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_DamLocationId",
                table: "LogModels",
                newName: "IX_LogModels_DamLocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogModels",
                table: "LogModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaitLogRelations_LogModels_LogId",
                table: "BaitLogRelations",
                column: "LogId",
                principalTable: "LogModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogModels_DamLocations_DamLocationId",
                table: "LogModels",
                column: "DamLocationId",
                principalTable: "DamLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogModels_FishSpecies_FishSpecieId",
                table: "LogModels",
                column: "FishSpecieId",
                principalTable: "FishSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogModels_Rigs_RigsId",
                table: "LogModels",
                column: "RigsId",
                principalTable: "Rigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogModels_Weather_WeatherId",
                table: "LogModels",
                column: "WeatherId",
                principalTable: "Weather",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
