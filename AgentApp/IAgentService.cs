using System.Threading.Tasks;

namespace AgentApp
{
    public interface IAgentService
    {
        public Task<AddResponse> AddNewItem(AddRequest request);
    }
}