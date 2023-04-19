using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Napelem_API.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "objectType",
                table: "Employees");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "project_description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "project_location",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "project_orderer",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "objectType",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
