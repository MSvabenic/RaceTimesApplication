using Microsoft.EntityFrameworkCore.Migrations;

namespace RaceTimesApplication.Data.Migrations
{
    public partial class DatabaseSeedAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "DDB8F0FD-B8A2-4582-B513-99605CA8B7F0", "f9ac6ee1-b2f6-4c49-ac74-01b773df4a69", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "F8BED3E7-1263-4705-B713-76965DE0EDFE", 0, "7e34fdc3-859f-4ed5-a21f-7a9a83e9ff6c", "AdminUser1@gmail.com", true, false, null, "ADMINUSER1@gmail.com", "ADMINUSER1@gmail.com", "AQAAAAEAACcQAAAAEGDSOLirRyu14DSS/iUikHYZrBD7trWZrnh/OhH1NjmijAD6kaoZE04izq6194LDZw==", null, false, "85344fa6-5661-4d6b-b147-cf699422d126", false, "AdminUser1@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "F8BED3E7-1263-4705-B713-76965DE0EDFE", "DDB8F0FD-B8A2-4582-B513-99605CA8B7F0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "F8BED3E7-1263-4705-B713-76965DE0EDFE", "DDB8F0FD-B8A2-4582-B513-99605CA8B7F0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "DDB8F0FD-B8A2-4582-B513-99605CA8B7F0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F8BED3E7-1263-4705-B713-76965DE0EDFE");
        }
    }
}
