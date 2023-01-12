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

        public async Task<int> Create(BlogModel model)
        {
            var item = new Blog()
            {
                Id = (Guid)model.Id,
                Image = model.Image,
                Title = model.Title,
                Content = model.Content,
                CreateDate = model.CreateDate
            };
            await _dbContext.Blogs.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.Blogs.FindAsync(id);
            _dbContext.Blogs.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> id)
        {
            foreach (var item in id)
            {
                var finditem = await _dbContext.Blogs.FindAsync(item);
                _dbContext.Blogs.Remove(finditem);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
        public async Task<IList<Blog>> GetAll()
        {
            var list = await _dbContext.Blogs.ToListAsync();
            return list;
        }

        public async Task<BlogModel> GetById(Guid id)
        {
            var query = from c in _dbContext.Blogs
                        join a in _dbContext.BlogsDetails on c.Id equals a.BlogId into pt
                        from tp in pt.DefaultIfEmpty()
                        where tp.Id == id
                        select new { c, tp };

            var entity = await query.Select(p => new BlogModel()
            {
                Id = p.c.Id,
                Image = p.c.Image,
                Title = p.c.Title,
                Content = p.c.Content,
                CreateDate = p.c.CreateDate,
                CommentId = p.tp.CommentID,
                ContentDetail = p.tp.Content,
            }).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<ApiResult<Pagingnation<BlogModel>>> GetPaging(BlogSeachContext ctx)
        {
            var query = from a in _dbContext.Blogs
                        join c in _dbContext.BlogsDetails on a.Id equals c.BlogId into pt
                        from tp in pt.DefaultIfEmpty()
                        select new { a, tp };
            if (!string.IsNullOrEmpty(ctx.Keyword))
            {
                query = query.Where(x => x.a.Title.Contains(ctx.Keyword));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((ctx.PageIndex - 1) * ctx.PageSize)
                .Take(ctx.PageSize)
                .Select(u => new BlogModel()
                {
                    Title = u.a.Title,
                    Id = u.a.Id,
                    Image = u.a.Image,
                    Content = u.a.Content,
                    CreateDate = u.a.CreateDate,
                    ContentDetail = u.tp.Content,
                    CommentId = u.tp.CommentID,
                    BlogId = u.tp.BlogId
                })
                .ToListAsync();
            var pagination = new Pagingnation<BlogModel>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = ctx.PageIndex,
                PageSize = ctx.PageSize,
            };

            return new ApiSuccessResult<Pagingnation<BlogModel>>(pagination);
        }

        public async Task<int> Update(BlogModel model)
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