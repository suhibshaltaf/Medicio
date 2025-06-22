using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "jop",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jop",
                table: "doctors");
        }
    }
}
