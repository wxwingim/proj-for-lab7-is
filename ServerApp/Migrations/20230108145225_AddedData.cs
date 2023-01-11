using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "inventory",
                column: "id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "item",
                columns: new[] { "id", "amount", "inventory_id", "inventory_number", "name" },
                values: new object[,]
                {
                    { 1, 2, 1, "0001", "Name1" },
                    { 2, 45, 1, "0002", "Name2" },
                    { 3, 1, 1, "0003", "Name3" },
                    { 4, 2, 2, "0001", "Name1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "item",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "item",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "item",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "item",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "inventory",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "inventory",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
