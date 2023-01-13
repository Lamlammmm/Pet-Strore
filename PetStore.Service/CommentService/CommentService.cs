using Microsoft.EntityFrameworkCore;
using Pet_Store.Common.Common;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.Comment;

namespace PetStore.Service
{
    public class CommentService : ICommentService
    {
        private readonly PetStoreDbContext _dbContext;

        public CommentService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Comment model)
        {
            var item = new Comment()
            {
                Id = Guid.NewGuid(),
                Content = model.Content,
                Date = DateTime.Now,
                UserId = model.UserId,
            };
            await _dbContext.Comments.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<Comment>> GetAll()
        {
            var list = await _dbContext.Comments.ToListAsync();
            return list;
        }

        public async Task<ApiResult<Pagingnation<Comment>>> GetAllPaging(CommentSeachContext ctx)
        {
            var query = from a in _dbContext.Comments
                        select new { a };
            if (!string.IsNullOrEmpty(ctx.Keyword))
            {
                query = query.Where(x => x.a.Content.Contains(ctx.Keyword));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((ctx.PageIndex - 1) * ctx.PageSize)
                .Take(ctx.PageSize)
                .Select(u => new Comment()
                {
                    UserId = u.a.UserId,
                    Content = u.a.Content,
                    Date = DateTime.Now,
                    Id = u.a.Id,
                })
                .ToListAsync();
            var pagination = new Pagingnation<Comment>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = ctx.PageIndex,
                PageSize = ctx.PageSize,
            };
            return new ApiSuccessResult<Pagingnation<Comment>>(pagination);
        }

        public async Task<Comment> GetById(Guid id)
        {
            var item = await _dbContext.Comments.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }
    }
}