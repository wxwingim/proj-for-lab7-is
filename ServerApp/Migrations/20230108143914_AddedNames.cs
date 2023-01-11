using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class AddedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Inventories_InventoryId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "item");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "inventory");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "item",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "item",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "item",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "InventoryNumber",
                table: "item",
                newName: "inventory_number");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "item",
                newName: "inventory_id");

            migrationBuilder.RenameIndex(
                name: "IX_Items_InventoryId",
                table: "item",
                newName: "IX_item_inventory_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "inventory",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item",
                table: "item",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory",
                table: "inventory",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_inventory_inventory_id",
                table: "item",
                column: "inventory_id",
                principalTable: "inventory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_inventory_inventory_id",
                table: "item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item",
                table: "item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory",
                table: "inventory");

            migrationBuilder.RenameTable(
                name: "item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "inventory",
                newName: "Inventories");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Items",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Items",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "inventory_number",
                table: "Items",
                newName: "InventoryNumber");

            migrationBuilder.RenameColumn(
                name: "inventory_id",
                table: "Items",
                newName: "InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_item_inventory_id",
                table: "Items",
                newName: "IX_Items_InventoryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Inventories",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Inventories_InventoryId",
                table: "Items",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
