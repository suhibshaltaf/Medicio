using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update_pricing_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "pricings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "pricings");
        }
    }
}
