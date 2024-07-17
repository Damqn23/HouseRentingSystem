using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastucture.Migrations
{
    public partial class AdminPasswordSeedCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "defd5ba6-9fe5-478a-890b-b773146d2826", "AQAAAAEAACcQAAAAEHgiyOi6KlJe6Rmi4u7SUixnfZg2TfOkOk9XNeWePPkGv6ox/FlkocORO5u7sShjqg==", "fe4271fe-42c4-4383-9386-99728d894fdb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "336ff1fe-527f-4708-8f65-2b425ca93c0c", "AQAAAAEAACcQAAAAEEbUpWyaOxUrv7ZmRcQRJUZcn7Gs9jb8VrcrMtpuGBJzFqm09BIkdNe6qjatKuHcnw==", "2b370a7a-0ea8-4784-92aa-264337d19511" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff3f474f-cb99-49c4-95a5-4da589759006", "AQAAAAEAACcQAAAAEFrfxQ/gwTybLD5hW8ifkn1MR8uzVUew+6eBESbdrTyVqBc9Z0SMfQt2wcQNRJSMog==", "05bf1cd7-96c2-4d70-a48d-7ea6dbf9bcf3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a468fe44-345d-423d-8ec4-d70e189c36a2", "AQAAAAEAACcQAAAAEKfVKwNcNE7gYYintuJ+fLBaD4jsKqXFcYgueRLoiY/Pz1A9SLz2uVeVSXBOFWlsow==", "93d2a55a-9f48-4074-89f8-ea6896136a59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aea9f83f-ac8a-4578-a8a4-37c841ec38c0", "AQAAAAEAACcQAAAAEKktp9brp46jEqDhboUZu9ZoCGnH0I7TujjF7EjMs22rgTQjPti+xiHBrqWbTfhAEg==", "8bea02cc-f68f-40c8-ad89-c2f45e0a4138" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6220378e-4448-457b-b96b-135b9a1ddd15", "AQAAAAEAACcQAAAAEIpIQBOt8YCPq6dmcsnIRYoarwimxgZXP9TZDMSlzUcmge6MeQv4y4LaXUs4B+rZCg==", "f37eb344-0974-46b0-ae10-fb879edb4bfc" });
        }
    }
}
