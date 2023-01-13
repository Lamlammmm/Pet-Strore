using Microsoft.EntityFrameworkCore;
using Pet_Store.Common.Common;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model;

namespace PetStore.Service
{
    public class BannerService : IBannerService
    {
        private readonly PetStoreDbContext _dbContext;

        public BannerService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Banner model)
        {
            var item = new Banner()
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                Image = model.Image,
                TypeBanner = model.TypeBanner,
            };
            await _dbContext.Banners.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> id)
        {
            foreach (var item in id)
            {
                var finditem = await _dbContext.Banners.FindAsync(item);
                _dbContext.Banners.Remove(finditem);
            }           
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.Banners.FindAsync(id);
            _dbContext.Banners.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<Banner>> GetAll()
        {
            var list = await _dbContext.Banners.ToListAsync();
            return list;
        }

        public async Task<Banner> GetById(Guid id)
        {
            var item = _dbContext.Banners.FirstOrDefault(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(Banner model)
        {
            var item = await _dbContext.Banners.FindAsync(model.Id);
            item.Title = model.Title;
            item.Content = model.Content;
            item.Image = model.Image;
            item.TypeBanner = model.TypeBanner;
            _dbContext.Banners.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<ApiResult<Pagingnation<Banner>>> GetAllPaging(BannerSeachContext ctx)
        {
            var query = from a in _dbContext.Banners
                        select new { a };
            if (!string.IsNullOrEmpty(ctx.Keyword))
            {
                query = query.Where(x => x.a.Title.Contains(ctx.Keyword));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((ctx.PageIndex - 1) * ctx.PageSize)
                .Take(ctx.PageSize)
                .Select(u => new Banner()
                {
                    Title = u.a.Title,
                    Content = u.a.Content,
                    Image= u.a.Image,
                    TypeBanner = u.a.TypeBanner,
                })
                .ToListAsync();
            var pagination = new Pagingnation<Banner>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = ctx.PageIndex,
                PageSize = ctx.PageSize,
            };

            return new ApiSuccessResult<Pagingnation<Banner>>(pagination);
        }
    }
}