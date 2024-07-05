using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastucture.Migrations
{
    public partial class UniqueConstraintForPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70041b00-b0d5-4be2-812d-253d2f84f3fd", "AQAAAAEAACcQAAAAED3/W9C2RjrnSWMT5d8uLzVtSuyR1Idmu0v2bpl3kQtGQR1G9uTMSU0k3t6K1mCXYg==", "8e3b9234-9bd0-440a-97ac-4c82e2ea2a07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87d3374a-325d-4c9e-a3c4-6056b6dfcd19", "AQAAAAEAACcQAAAAEBVqSTi2xOzd9lKYG5F2N4Z8MkV6ZCjvYa+dlg+vmKBnB06sBbRXS7vbautI0b+ZrQ==", "b73c05b5-fefb-4989-849e-259ccab2c093" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f3e5815-db6f-469a-8ce0-de44e205ac3a", "AQAAAAEAACcQAAAAEJnyUchKnUw2F/P6HXwWVV+MSD1SypXL/v31x0IQpAwatVIeKzVLVsB3SropGEhVZg==", "33b700ec-4de5-4b38-b865-91cb51ecab4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "548a091d-7c3a-486b-b201-a3c0eff71d39", "AQAAAAEAACcQAAAAEPUZ/nw9eQGZ892pPGSRF92SmjojGgMbtp6XbAqwNetkgw3aHVI3wmlO7A0pnb4qUA==", "fdb15dab-3c13-426d-b47a-d6ba8b507822" });
        }
    }
}
