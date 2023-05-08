using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Napelem_API.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "objectType",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "objectType",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
