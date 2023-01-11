using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseEntities
{
    [Table("inventory")]
    public class Inventory : BaseModel
    {
        public Inventory()
        {
            Items = new List<Item>();
        }
        
        // [Column("id")]
        // public int Id { get; set; }
        
        public List<Item> Items { get; set; }
    }
}