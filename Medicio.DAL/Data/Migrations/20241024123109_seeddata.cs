using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medicio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "092bffb8-d51d-4321-afc5-76591f799b74", null, "SuperAdmin", "SUPERADMIN" },
                    { "0de4e016-932d-47c0-9e53-346b5b0ab6f5", null, "Admin", "ADMIN" },
                    { "2eeb68c2-c6a7-40f1-91c4-6e8356d495d4", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "232c1c85-a34f-4d10-88b6-bf8ae4b004ed", 0, null, "d07b2eb7-76d9-4926-ae5a-4eb2b724c747", "superadmin@medc.com", true, null, false, null, "SUPERADMIN@MEDC.COM", "SUPERADMIN@MEDC.COM", "AQAAAAIAAYagAAAAEJOsEXVFJgraZhWRcpIdaW3GJBZAg+Z5rFKsLD/oCFRLRzRuiwNdD3ctWGDBTuK06w==", null, false, "8f312260-7fe5-4629-a90a-3bb60bac3640", false, "superadmin@medc.com" },
                    { "cb062502-3a36-4c92-9942-f8d8329cde2c", 0, null, "f2c23e39-d5d7-4a01-93bc-08a111d1e3f5", "user@medc.com", true, null, false, null, "USER@MEDC.COM", "USER@MEDC.COM", "AQAAAAIAAYagAAAAEPBh+5QjT5TfJ4/Iv3EMbS/RrR6CvfFywwq4ohZDD9wFllrAS/IFZ2pVp2vV6Xstbg==", null, false, "a9825aac-5177-4ef8-812f-0724f9362484", false, "user@medc.com" },
                    { "e33a6a4c-9b0b-4237-8ff0-3ca37cc125b8", 0, null, "c98a7fc3-3589-4e84-97ee-9b006da6ab94", "admin@medc.com", true, null, false, null, "ADMIN@MEDC.COM", "ADMIN@MEDC.COM", "AQAAAAIAAYagAAAAEAxlj5781nu+gy5rt3Me3rRC6QstoY9k24kOit4sZLTKFPl80Zyb6qAXAw4THl+Ihw==", null, false, "d80031ca-37de-4eeb-bae2-acf34eb30414", false, "admin@medc.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "092bffb8-d51d-4321-afc5-76591f799b74", "232c1c85-a34f-4d10-88b6-bf8ae4b004ed" },
                    { "2eeb68c2-c6a7-40f1-91c4-6e8356d495d4", "cb062502-3a36-4c92-9942-f8d8329cde2c" },
                    { "0de4e016-932d-47c0-9e53-346b5b0ab6f5", "e33a6a4c-9b0b-4237-8ff0-3ca37cc125b8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "092bffb8-d51d-4321-afc5-76591f799b74", "232c1c85-a34f-4d10-88b6-bf8ae4b004ed" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2eeb68c2-c6a7-40f1-91c4-6e8356d495d4", "cb062502-3a36-4c92-9942-f8d8329cde2c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0de4e016-932d-47c0-9e53-346b5b0ab6f5", "e33a6a4c-9b0b-4237-8ff0-3ca37cc125b8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "092bffb8-d51d-4321-afc5-76591f799b74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0de4e016-932d-47c0-9e53-346b5b0ab6f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2eeb68c2-c6a7-40f1-91c4-6e8356d495d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "232c1c85-a34f-4d10-88b6-bf8ae4b004ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb062502-3a36-4c92-9942-f8d8329cde2c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e33a6a4c-9b0b-4237-8ff0-3ca37cc125b8");
        }
    }
}
