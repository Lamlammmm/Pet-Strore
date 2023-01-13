using Microsoft.EntityFrameworkCore;
using Pet_Store.Common.Common;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model;
using PetStore.Model.About;
using PetStore.Model.Banner;
using PetStore.Model.MenuItem;

namespace PetStore.Service
{
    public class BannerService : IBannerService
    {
        private readonly PetStoreDbContext _dbContext;

        public BannerService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(BannerModel model)
        {
            var item = new Banner()
            {
                Id = Guid.NewGuid(),
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

        public async Task<IList<BannerModel>> GetAll()
        {
            var query = from c in _dbContext.Banners
                        where c.TypeBanner == 10
                        select new { c };
            var entity = await query.Select(x => new BannerModel()
            {
                Id = x.c.Id,
                Content = x.c.Content,
                Image = x.c.Image,
                Title = x.c.Title,
                TypeBanner= x.c.TypeBanner
            }).ToListAsync();

            return entity;
        }

        public async Task<BannerModel> GetById(Guid id)
        {
            var entity = await _dbContext.Banners.FirstOrDefaultAsync(c => c.Id == id);

            var entityModel = new BannerModel()
            {
                Id = entity.Id,
                Content=entity.Content,
                Title=entity.Title,
                Image=entity.Image,
                TypeBanner = entity.TypeBanner,
            };
            return entityModel;
        }

        public async Task<int> Update(BannerModel model)
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