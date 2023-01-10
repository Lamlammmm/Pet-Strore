using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public class BlogDetailService : IBlogDetailService
    {
        private readonly PetStoreDbContext _dbContext;

        public BlogDetailService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(BlogDetail model)
        {
            var item = new BlogDetail()
            {
                Id = model.Id,
                CommentID = model.CommentID,
                Content = model.Content,
            };
            await _dbContext.BlogsDetails.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteById( IEnumerable<Guid> id)
        {
            foreach (var items in id)
            {
            var item = await _dbContext.BlogsDetails.FindAsync(id);
            _dbContext.BlogsDetails.Remove(item);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<BlogDetail>> GetAll()
        {
            var list = await _dbContext.BlogsDetails.ToListAsync();
            return list;
        }

        public async Task<BlogDetail> GetById(Guid id)
        {
            var item = await _dbContext.BlogsDetails.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(BlogDetail model)
        {
            var item = await _dbContext.BlogsDetails.FindAsync(model.Id);
            item.Content = model.Content;
            item.CommentID = model.CommentID;
            _dbContext.BlogsDetails.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}