using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Napelem_API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estimated_Time",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "project_description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "project_location",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "project_orderer",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "wage",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estimated_Time",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "project_description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "project_location",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "project_orderer",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "wage",
                table: "Projects");
        }
    }
}
