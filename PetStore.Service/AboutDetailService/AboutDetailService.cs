using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Model.AboutDetail;

namespace PetStore.Service
{
    public class AboutDetailService : IAboutDetailService
    {
        private readonly PetStoreDbContext _dbContext;

        public AboutDetailService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(AboutDetailModel model)
        {
            var create = new AboutDetail()
            {
                Id = Guid.NewGuid(),
                ContenDetail = model.ContenDetail,
                CatagoryDetail = model.CatagoryDetail,
                AboutId = model.AboutId,
            };
            await _dbContext.AboutDetails.AddAsync(create);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.AboutDetails.FindAsync(id);
            _dbContext.AboutDetails.Remove(item);
            var resault = await _dbContext.SaveChangesAsync();
            return resault;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> id)
        {
            foreach (var item in id)
            {
                var finditem = await _dbContext.AboutDetails.FindAsync(item);
                _dbContext.AboutDetails.Remove(finditem);
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

        public async Task<int> Update(AboutDetailModel model)
        {
            var item = await _dbContext.AboutDetails.FirstOrDefaultAsync(c => c.AboutId == model.AboutId);
            item.ContenDetail = model.ContenDetail;
            item.CatagoryDetail = model.CatagoryDetail;
            item.AboutId = model.AboutId;
            _dbContext.AboutDetails.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}