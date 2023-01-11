using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientApp.Repositories
{
    public interface IClientRepositories<TDbModel> where TDbModel : DataBaseEntities.BaseModel
    {
        Task<IEnumerable<TDbModel>> GetAll();
    }
}
