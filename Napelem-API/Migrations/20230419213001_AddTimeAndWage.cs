using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Napelem_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeAndWage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "estimated_Time",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "wage",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estimated_Time",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "wage",
                table: "Projects");
        }
    }
}
