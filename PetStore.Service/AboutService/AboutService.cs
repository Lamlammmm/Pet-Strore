using Microsoft.EntityFrameworkCore;
using Pet_Store.Common.Common;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.About;

namespace PetStore.Service
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
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content,
                Image = model.Image,
            };
            await _dbContext.Abouts.AddAsync(Item);
            var Result = await _dbContext.SaveChangesAsync();
            return Result;
        }

        public async Task<int> DeleteById(IEnumerable<Guid> id)
        {
            foreach (var items in id)
            {
                var Item = await _dbContext.Abouts.FindAsync(id);
            _dbContext.Abouts.Remove(Item);
            } 
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

        public async Task<ApiResult<Pagingnation<About>>> GetPaging(AboutSeachContext ctx)
        {
            var query = from a in _dbContext.Abouts
                        select new { a };
            if (!string.IsNullOrEmpty(ctx.Keyword))
            {
                query = query.Where(x => x.a.Title.Contains(ctx.Keyword));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((ctx.PageIndex - 1) * ctx.PageSize)
                .Take(ctx.PageSize)
                .Select(u => new About()
                {
                    Title = u.a.Title,
                    Content = u.a.Content,
                    Image = u.a.Image,
                    Id = u.a.Id,
                })
                .ToListAsync();
            var pagination = new Pagingnation<About>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = ctx.PageIndex,
                PageSize = ctx.PageSize,
            };

            return new ApiSuccessResult<Pagingnation<About>>(pagination);
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