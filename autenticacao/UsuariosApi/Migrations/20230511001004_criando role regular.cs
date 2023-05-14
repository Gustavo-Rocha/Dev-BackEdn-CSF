using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "0103ef2b-2359-4711-858d-c524d8042238");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "73987d0f-61b7-4ce2-935e-2c802a35a87d", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "000d14b1-1465-4374-8eed-2ff51a2eb14b", "AQAAAAEAACcQAAAAEKlOVgGc1bFXM+ZRjU7UQDWFQFYy8QwWbtyYPmu+oyrFoGDBUv6KNBTPC7xbYbpgsA==", "36143c3d-a816-4709-bd79-be0a9f66e4ea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "f580ac9d-ad60-4dea-9b70-021d86de75c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f2141e4-9ad7-4615-a531-f4e07c2c9edc", "AQAAAAEAACcQAAAAEDLgoXh5RkrGVqilxjUIiKori98OvEdKEcoHa8+2lrvN1hHMBorDx4/Sxbr4A4HV8w==", "1f672a4d-3fb6-4177-bc42-f8e17f0e31ac" });
        }
    }
}
