using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseEntities;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using ServerApp.Repositories;

namespace ServerApp
{
    public class GreeterService : Agent.AgentBase
    {
        private readonly ILogger<GreeterService> _logger;
        private IBaseRepository<Item> Items { get; set; }


        public GreeterService(IBaseRepository<Item> Items)
        {
            this.Items = Items;
        }

        public override Task<AddResponse> AddNewItem(AddRequest request, ServerCallContext context)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Number))
                {
                    throw new Exception("Empty data.");
                }
                Item item = new Item { Name = request.Name, InventoryNumber = request.Number, Amount = request.Amount, InventoryId = 1 };
                Items.Create(item);
                return Task.FromResult(new AddResponse
                {
                    Res = true,
                });
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Task.FromResult(new AddResponse
                {
                    Res = false,
                });
            }


        }
    }
}