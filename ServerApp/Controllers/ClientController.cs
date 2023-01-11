using System.Collections.Generic;
using System.Reflection.Metadata;
using DataBaseEntities;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Repositories;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("/clients")]
    public class ClientController: ControllerBase
    {
        private IBaseRepository<Item> _items { get; set; }

        public ClientController(IBaseRepository<Item> items)
        {
            _items = items;
        }

        [HttpGet]
        public IEnumerable<Item> GetAllItems()
        {
            return _items.GetAll();
        }
        

    }
}