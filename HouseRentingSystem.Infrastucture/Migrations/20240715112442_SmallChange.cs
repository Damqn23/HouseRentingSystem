using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastucture.Migrations
{
    public partial class SmallChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Houses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "House description",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "House description");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Houses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "House description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "House description");

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
        }
    }
}
