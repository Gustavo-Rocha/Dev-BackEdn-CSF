using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "c4cda5d7-467e-4832-bf27-a74622693dd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a61601c3-39a7-49b6-83ac-e6a5ce4e775a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f053d8f6-3ea7-4f27-ac0f-85c6ecf5f42c", "AQAAAAEAACcQAAAAEEflx/l4IpXxMvvYfr1MmKIm1ej2AONe1hNLLX79ZVvX9rdM/gPDE+lwhLhiODwkTg==", "bd917378-70eb-4a9a-a6b8-d5d6b5b0d71b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "73987d0f-61b7-4ce2-935e-2c802a35a87d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "0103ef2b-2359-4711-858d-c524d8042238");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "000d14b1-1465-4374-8eed-2ff51a2eb14b", "AQAAAAEAACcQAAAAEKlOVgGc1bFXM+ZRjU7UQDWFQFYy8QwWbtyYPmu+oyrFoGDBUv6KNBTPC7xbYbpgsA==", "36143c3d-a816-4709-bd79-be0a9f66e4ea" });
        }
    }
}
