using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseEntities
{
    [Table("item")]
    public class Item : BaseModel
    {
        // [Column("id")]
        // public int Id { get; set; }

        [Column("inventory_number")]
        public string InventoryNumber { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("amount")]
        public int Amount { get; set; }

        public Inventory Inventory { get; set; }

        [Column("inventory_id")]
        public int InventoryId { get; set; }

        public Item()
        {
            InventoryNumber = "";
            Name = "";
            Amount = 0;
            Inventory = new Inventory();
        }

        public Item(string inventoryNumber, string name, int amount, Inventory inventory, int inventoryId)
        {
            InventoryNumber = inventoryNumber;
            Name = name;
            Amount = amount;
            Inventory = inventory;
            InventoryId = inventoryId;
        }
    }
}