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

        public async Task<int> Create(AboutModel model)
        {
            var Item = new About()
            {
                Id = (Guid)model.Id,
                Title = model.Title,
                Content = model.Content,
                Image = model.Image,
            };
            await _dbContext.Abouts.AddAsync(Item);
            var Result = await _dbContext.SaveChangesAsync();
            return Result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.Abouts.FindAsync(id);
            _dbContext.Abouts.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> id)
        {
            foreach (var items in id)
            {
                var Item = await _dbContext.Abouts.FindAsync(items);
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

        public async Task<AboutModel> GetById(Guid id)
        {
            var query = from c in _dbContext.Abouts
                        join a in _dbContext.AboutDetails on c.Id equals a.AboutId into pt
                        from tp in pt.DefaultIfEmpty()
                        where c.Id == id
                        select new { c, tp };
            var entity = await query.Select(x => new AboutModel()
            {
                Id = x.c.Id,
                Content = x.c.Content,
                Image = x.c.Image,
                Title = x.c.Title,
                AboutId = x.tp.AboutId,
                CatagoryDetail = x.tp.CatagoryDetail,
                ContenDetail = x.tp.ContenDetail
            }).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<ApiResult<Pagingnation<AboutModel>>> GetPaging(AboutSeachContext ctx)
        {
            var query = from a in _dbContext.Abouts
                        join c in _dbContext.AboutDetails on a.Id equals c.AboutId into pt
                        from tp in pt.DefaultIfEmpty()
                        select new { a, tp };
            if (!string.IsNullOrEmpty(ctx.Keyword))
            {
                query = query.Where(x => x.a.Title.Contains(ctx.Keyword));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((ctx.PageIndex - 1) * ctx.PageSize)
                .Take(ctx.PageSize)
                .Select(u => new AboutModel()
                {
                    Title = u.a.Title,
                    Content = u.a.Content,
                    Image = u.a.Image,
                    Id = u.a.Id,
                    AboutId = u.a.Id,
                    CatagoryDetail = u.tp.CatagoryDetail,
                    ContenDetail = u.tp.ContenDetail
                })
                .ToListAsync();
            var pagination = new Pagingnation<AboutModel>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = ctx.PageIndex,
                PageSize = ctx.PageSize,
            };

            return new ApiSuccessResult<Pagingnation<AboutModel>>(pagination);
        }

        public async Task<int> Update(AboutModel model)
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