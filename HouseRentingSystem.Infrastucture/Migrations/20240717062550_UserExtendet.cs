using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastucture.Migrations
{
    public partial class UserExtendet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29dbb149-0912-4f82-9729-28983542efb7", "", "", "AQAAAAEAACcQAAAAEKn1iT4dFgvNUl6yXnMKZZlzWYXyx0WoRc67DfSBOFOVpNIi1K/n/XLvSJO7DupluQ==", "8d020ce3-2e2e-404d-a53a-74540f22fb26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54883efa-76ab-4739-a614-3bb7b8da956b", "", "", "AQAAAAEAACcQAAAAEF8rYoogENYDMgXBHTyzgyCqXBTPdBeDrhIrtTCe/vtJe5w/udUo5ZoGhiOqIkSsiA==", "22f2f5f5-6880-45b2-a6d2-06b566b68ee6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb9a75a8-8266-4da4-aec8-f0ff8e018fbf", "AQAAAAEAACcQAAAAEH9yDVfyZECi9ebT0OPbeU9AsktJSOppyl0zgrsloeVXAKqRN4l4+2BFWk66fXc7OQ==", "8d6fcee0-25c1-4474-893c-eae45a14498e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "134e61d2-6ab2-4cd6-b4f3-93012ca53710", "AQAAAAEAACcQAAAAEAE17TtZc9P5R9J7Dr3vxshxVpxcCZhY7BB2uB6LM0R4KYpg7bvfK7zyo6n8FLRRNw==", "b0a0c823-966c-414e-a6b5-cb2e7865b21d" });
        }
    }
}
