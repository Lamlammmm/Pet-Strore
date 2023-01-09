using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AboutDetailService
{
    public class AboutDetailService : IAboutDetailService
    {
        private readonly PetStoreDbContext _dbContext;
        public AboutDetailService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> Create(About model)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<About>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<About> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(About model)
        {
            throw new NotImplementedException();
        }
    }
}
