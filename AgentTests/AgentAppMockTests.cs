using System.Threading.Tasks;
using AgentApp;
using Moq;
using Xunit;

namespace AgentTests
{
    public class AgentAppMockTests
    {
        [Fact]
        public async Task AddNewItem_Success()
        {
            var mock = new Mock<IAgentService>();
            mock.Setup(s => s.AddNewItem(It.IsNotNull<AddRequest>()))
                .Returns(Task.FromResult(new AddResponse() { Res = true }));
            var worker = new ItemsAgent(mock.Object);
            var res = await worker.AddNewItem(new AddRequest()
                { Number = "0008", Name = "name", Amount = 42});
            Assert.Equal(res.Res, true);
        }
        
        [Fact]
        public async Task AddNewItem_WithNull()
        {
            var mock = new Mock<IAgentService>();
            mock.Setup(s => s.AddNewItem(It.Is<AddRequest>(r => r == null)))
                .Returns(Task.FromResult(new AddResponse() { Res = false }));
            var worker = new ItemsAgent(mock.Object);
            var res = await worker.AddNewItem(null);
            Assert.Equal(res.Res, false);
        }
        
        [Theory]
        [InlineData("  ", "name", 1)]
        [InlineData("123", "  ", 1)]
        public async Task AddNewItem_WithEmptyData(string number, string name, int amount)
        {
            var mock = new Mock<IAgentService>();
            mock.Setup(s =>
                s.AddNewItem(It.Is<AddRequest>(
                    r => string.IsNullOrWhiteSpace(r.Name) || !string.IsNullOrWhiteSpace(r.Number)))).Returns(
                Task.FromResult(new AddResponse()
                    {Res = false}));
            var worker = new ItemsAgent(mock.Object);
            var res = await worker.AddNewItem(new AddRequest(){Number = number, Name = name, Amount = amount});
            Assert.Equal(res.Res, false);
        }
        
        [Theory]
        [InlineData(null)]
        public async Task AddNewItem_WithFailData(int amount)
        {
            var mock = new Mock<IAgentService>();
            mock.Setup(s =>
                s.AddNewItem(It.Is<AddRequest>(
                    r => r.Amount.GetType() != typeof(int)))).Returns(
                Task.FromResult(new AddResponse()
                    {Res = false}));
            var worker = new ItemsAgent(mock.Object);
            var res = await worker.AddNewItem(new AddRequest(){Number = "smth", Name = "smth", Amount = amount});
            Assert.Equal(res.Res, false);
        }
    }
}