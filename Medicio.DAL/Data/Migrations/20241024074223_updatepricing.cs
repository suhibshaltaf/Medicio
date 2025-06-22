using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatepricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Isna",
                table: "pricings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isna",
                table: "pricings");
        }
    }
}
