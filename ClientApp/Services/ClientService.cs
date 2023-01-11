using ClientApp.Repositories;
using DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class ClientService<TDbModel> : IClientRepositories<TDbModel> where TDbModel : BaseModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly HttpClient _httpClient;

        public ClientService() { }

        public ClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }
        public async Task<IEnumerable<TDbModel>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            try
            {
                var responseMessage = await client.GetAsync("http://localhost:5002/clients/");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<IEnumerable<TDbModel>>(await responseMessage.Content
                        .ReadAsStringAsync()) ?? Enumerable.Empty<TDbModel>();
                }
                return Enumerable.Empty<TDbModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Enumerable.Empty<TDbModel>();
            }
        }
    }
}
