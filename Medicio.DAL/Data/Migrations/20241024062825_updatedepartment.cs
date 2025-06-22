using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tabs",
                table: "departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tabs",
                table: "departments");
        }
    }
}
