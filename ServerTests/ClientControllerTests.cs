using System;
using System.Collections.Generic;
using System.Linq;
using DataBaseEntities;
using Moq;
using ServerApp;
using ServerApp.Controllers;
using ServerApp.Repositories;
using Xunit;

namespace ServerTests
{
    public class ClientControllerTests
    {
        public ClientControllerTests()
        {
            var testItem = new List<Item>();
            for (var i = 1; i < 3; i++)
            {
                var item = new Item {Id = i, InventoryNumber = "000" + i, Name = "Entity" + i, Amount = i, InventoryId = i};
                testItem.Add(item);
            }

            _testItem = testItem;
        }

        private readonly List<Item> _testItem;

        [Fact]
        public void GetAllItems_ValidCall()
        {
            var mock = new Mock<IBaseRepository<Item>>();
            mock.Setup(r => r.GetAll()).Returns(_testItem);
            var clientController = new ClientController(mock.Object);
            var result = clientController.GetAllItems();
            
            Assert.Equal(_testItem.Count, result.Count());
        }

        [Fact]
        public void CreateItem_Success()
        {
            var mock = new Mock<IBaseRepository<Item>>();
            mock.Setup(s => s.Create(It.IsNotNull<Item>()))
                .Returns(new Item {InventoryNumber = "smth", Name = "smth", Amount = 1});
            var agentController = new GreeterService(mock.Object);
            var res = agentController.AddNewItem(new AddRequest(), null);
            
            Assert.Equal(res.Result.Res, true);
        }
        
        [Theory]
        [InlineData("  ", "name", 1)]
        [InlineData("123", "  ", 1)]
        public void CreateItem_WithEmptyData(string number, string name, int amount)
        {
            var mock = new Mock<IBaseRepository<Item>>();
            mock.Setup(s => s.Create(It.Is<Item>(
                    i => string.IsNullOrWhiteSpace(i.Name) || string.IsNullOrWhiteSpace(i.InventoryNumber))))
                .Returns(new Item());
            var agentController = new GreeterService(mock.Object);
            var res = agentController.AddNewItem(new AddRequest() {Number = number, Name = name, Amount = amount}, null);
            
            Assert.Equal(res.Result.Res, false);
        }
    }
}