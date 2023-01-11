using Grpc.Net.Client;
using System.Threading.Tasks;

namespace AgentApp
{
    public class AgentService : IAgentService
    {
        public async Task<AddResponse> AddNewItem(AddRequest request)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5002");
            var client = new Agent.AgentClient(channel);
            return await client.AddNewItemAsync(request);
        }
    }
}