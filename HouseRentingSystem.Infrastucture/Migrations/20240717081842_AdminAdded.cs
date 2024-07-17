using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastucture.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aea9f83f-ac8a-4578-a8a4-37c841ec38c0", "Guest", "Guestov", "AQAAAAEAACcQAAAAEKktp9brp46jEqDhboUZu9ZoCGnH0I7TujjF7EjMs22rgTQjPti+xiHBrqWbTfhAEg==", "8bea02cc-f68f-40c8-ad89-c2f45e0a4138" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6220378e-4448-457b-b96b-135b9a1ddd15", "Agent", "Agentov", "AQAAAAEAACcQAAAAEIpIQBOt8YCPq6dmcsnIRYoarwimxgZXP9TZDMSlzUcmge6MeQv4y4LaXUs4B+rZCg==", "f37eb344-0974-46b0-ae10-fb879edb4bfc" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3f4631bd-f907-4409-b416-ba356312e659", 0, "a468fe44-345d-423d-8ec4-d70e189c36a2", "admin@mail.com", false, "Admin", "Adminov", false, null, "ADMIN@MAIN.COM", "ADMIN@MAIN.COM", "AQAAAAEAACcQAAAAEKfVKwNcNE7gYYintuJ+fLBaD4jsKqXFcYgueRLoiY/Pz1A9SLz2uVeVSXBOFWlsow==", null, false, "93d2a55a-9f48-4074-89f8-ea6896136a59", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 7, "+359999999999", "3f4631bd-f907-4409-b416-ba356312e659" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659");

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
    }
}
