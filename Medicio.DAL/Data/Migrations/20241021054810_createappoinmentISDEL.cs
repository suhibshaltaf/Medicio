﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class createappoinmentISDEL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "appointments");
        }
    }
}
