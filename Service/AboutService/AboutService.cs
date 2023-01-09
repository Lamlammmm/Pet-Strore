using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;

namespace Service.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly PetStoreDbContext _dbContext;

        public AboutService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(About model)
        {
            var Item = new About()
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                Image = model.Image,
            };
            await _dbContext.Abouts.AddAsync(Item);
            var Result = await _dbContext.SaveChangesAsync();
            return Result;
        }

        public async Task<int> DeleteById(Guid id)
        {
            var Item = await _dbContext.Abouts.FindAsync(id);
            _dbContext.Abouts.Remove(Item);
            var Result = await _dbContext.SaveChangesAsync();
            return Result;
        }

        public async Task<IList<About>> GetAll()
        {
            var About = await _dbContext.Abouts.ToListAsync();
            return About;
        }

        public async Task<About> GetById(Guid id)
        {
            var AboutId = await _dbContext.Abouts.FirstOrDefaultAsync(a => a.Id == id);
            return AboutId;
        }

        public Task<ApiResult<Pagingnation<About>>> GetPaging(About model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(About model)
        {
            var Item = await _dbContext.Abouts.FindAsync(model.Id);
            Item.Title = model.Title;
            Item.Content = model.Content;
            Item.Image = model.Image;
            _dbContext.Abouts.Update(Item);
            var Result = await _dbContext.SaveChangesAsync();
            return Result;
        }
    }
}