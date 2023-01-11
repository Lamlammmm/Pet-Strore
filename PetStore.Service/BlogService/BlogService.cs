using Microsoft.EntityFrameworkCore;
using Pet_Store.Common.Common;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.Blog;

namespace PetStore.Service
{
    public class BlogService : IBlogService
    {
        private readonly PetStoreDbContext _dbContext;

        public BlogService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Blog model)
        {
            var item = new Blog()
            {
                Id = model.Id,
                Image = model.Image,
                Title = model.Title,
                Content = model.Content,
                CreateDate = model.CreateDate
            };
            await _dbContext.Blogs.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteById(IEnumerable<Guid> id)
        {
            foreach (var item in id)
            {
                var finditem = await _dbContext.Blogs.FindAsync(item);
                _dbContext.Blogs.Remove(finditem);
            }
            var result = await _dbContext.SaveChangesAsync() ;
            return result;
        }

        public async Task<IList<Blog>> GetAll()
        {
            var list = await _dbContext.Blogs.ToListAsync();
            return list;
        }

        public async Task<Blog> GetById(Guid id)
        {
            var item = await _dbContext.Blogs.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<ApiResult<Pagingnation<Blog>>> GetPaging(BlogSeachContext ctx)
        {
            var query = from a in _dbContext.Blogs
                        select new { a };
            if (!string.IsNullOrEmpty(ctx.Keyword))
            {
                query = query.Where(x => x.a.Title.Contains(ctx.Keyword));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((ctx.PageIndex - 1) * ctx.PageSize)
                .Take(ctx.PageSize)
                .Select(u => new Blog()
                {
                    Title = u.a.Title,
                    Id = u.a.Id,
                    Image = u.a.Image,
                    Content = u.a.Content,
                    CreateDate = u.a.CreateDate,
                })
                .ToListAsync();
            var pagination = new Pagingnation<Blog>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = ctx.PageIndex,
                PageSize = ctx.PageSize,
            };

            return new ApiSuccessResult<Pagingnation<Blog>>(pagination);
        }

        public async Task<int> Update(Blog model)
        {
            var item = await _dbContext.Blogs.FindAsync(model.Id);
            item.Image = model.Image;
            item.Title = model.Title;
            item.Content = model.Content;
            item.CreateDate = model.CreateDate;
            _dbContext.Blogs.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}