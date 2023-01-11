using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgentApp
{
    public class ItemsAgent
    {
        private readonly IAgentService _agentService;

        public ItemsAgent(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public async Task<AddResponse> AddNewItem(AddRequest request)
        {
            if (request is null || request.Amount <= 0 || string.IsNullOrWhiteSpace(request.Number)) return new AddResponse { Res = false };
            return await _agentService.AddNewItem(request);
        }
    }
}
