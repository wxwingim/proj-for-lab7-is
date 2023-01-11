using System;
using DataBaseEntities;
using System.Collections.Generic;
using System.Linq;

namespace ServerApp.Repositories
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel: BaseModel
    {
        //private ApplicationContext Context { get; set; }

        public BaseRepository()
        {
            //Context = context;
        }

        public TDbModel Create(TDbModel model)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    dbContext.Set<TDbModel>().Add(model);
                    dbContext.SaveChanges();
                }

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                model.Id = 0;
                return model;
            }

        }


        public List<TDbModel> GetAll()
        {
            using (var dbContext = new ApplicationContext())
            {
                return dbContext.Set<TDbModel>().ToList();
            }
            
        }


        public TDbModel Get(int id)
        {
            using (var dbContext = new ApplicationContext())
            {
                return dbContext.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
            }
            
        }
    }
}
