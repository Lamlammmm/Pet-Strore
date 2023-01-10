using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public class AboutDetailService : IAboutDetailService
    {
        private readonly PetStoreDbContext _dbContext;

        public AboutDetailService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(AboutDetail model)
        {
            var create = new AboutDetail()
            {
                Id = model.Id,
                ContenDetail = model.ContenDetail,
                CatagoryDetail = model.CatagoryDetail,
            };
            await _dbContext.AboutDetails.AddAsync(create);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteById(IEnumerable<Guid> id)
        {
            foreach (var items in id)
            {
                var item = await _dbContext.AboutDetails.FindAsync(id);
            _dbContext.AboutDetails.Remove(item);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<AboutDetail>> GetAll()
        {
            var list = await _dbContext.AboutDetails.ToListAsync();
            return list;
        }

        public async Task<AboutDetail> GetById(Guid id)
        {
            var item = await _dbContext.AboutDetails.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(AboutDetail model)
        {
            var item = await _dbContext.AboutDetails.FindAsync(model.Id);
            item.ContenDetail = model.ContenDetail;
            item.CatagoryDetail = model.CatagoryDetail;
            _dbContext.AboutDetails.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}