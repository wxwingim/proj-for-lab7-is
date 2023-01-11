using DataBaseEntities;
using System.Collections.Generic;

namespace ClientApp.Models
{
    public class ItemViewModel
    {
        public IEnumerable<Item> Items { get; set; }

        public ItemViewModel()
        {
            Items = new List<Item>();
        }

        public ItemViewModel(IEnumerable<Item> items)
        {
            Items = items;
        }
    }
}
