using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Napelem_API.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Storages",
                newName: "current_quantity");

            migrationBuilder.RenameColumn(
                name: "current_quantity",
                table: "Components",
                newName: "quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "current_quantity",
                table: "Storages",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Components",
                newName: "current_quantity");
        }
    }
}
