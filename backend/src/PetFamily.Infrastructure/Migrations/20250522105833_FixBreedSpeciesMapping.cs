using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixBreedSpeciesMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_breeds_species_breed_id",
                table: "breeds");

            migrationBuilder.RenameColumn(
                name: "breed_id",
                table: "breeds",
                newName: "species_id");

            migrationBuilder.RenameIndex(
                name: "ix_breeds_breed_id",
                table: "breeds",
                newName: "ix_breeds_species_id");

            migrationBuilder.AddForeignKey(
                name: "fk_breeds_species_species_id",
                table: "breeds",
                column: "species_id",
                principalTable: "species",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_breeds_species_species_id",
                table: "breeds");

            migrationBuilder.RenameColumn(
                name: "species_id",
                table: "breeds",
                newName: "breed_id");

            migrationBuilder.RenameIndex(
                name: "ix_breeds_species_id",
                table: "breeds",
                newName: "ix_breeds_breed_id");

            migrationBuilder.AddForeignKey(
                name: "fk_breeds_species_breed_id",
                table: "breeds",
                column: "breed_id",
                principalTable: "species",
                principalColumn: "id");
        }
    }
}
