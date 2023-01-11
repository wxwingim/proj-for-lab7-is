using System.Reflection.Metadata;
using DataBaseEntities;
using ServerApp.Repositories;

namespace ServerApp
{
    public class ClientService
    {
        
        
        private IBaseRepository<Item> Items { get; set; }
        private IBaseRepository<Inventory> Inventories { get; set; }
    }
}