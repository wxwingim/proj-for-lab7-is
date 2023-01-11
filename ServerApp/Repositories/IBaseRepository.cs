using DataBaseEntities;
using System.Collections.Generic;

namespace ServerApp.Repositories
{
    public interface IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        public List<TDbModel> GetAll();
        public TDbModel Get(int id);
        public TDbModel Create(TDbModel model);
    }
}
