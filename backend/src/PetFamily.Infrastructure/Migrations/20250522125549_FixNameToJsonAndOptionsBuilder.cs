using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixNameToJsonAndOptionsBuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Requisites",
                table: "volunteers",
                newName: "requisites");

            migrationBuilder.RenameColumn(
                name: "SocialNetworks",
                table: "volunteers",
                newName: "social_networks");

            migrationBuilder.RenameColumn(
                name: "Requisites",
                table: "pets",
                newName: "requisites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "requisites",
                table: "volunteers",
                newName: "Requisites");

            migrationBuilder.RenameColumn(
                name: "social_networks",
                table: "volunteers",
                newName: "SocialNetworks");

            migrationBuilder.RenameColumn(
                name: "requisites",
                table: "pets",
                newName: "Requisites");
        }
    }
}
