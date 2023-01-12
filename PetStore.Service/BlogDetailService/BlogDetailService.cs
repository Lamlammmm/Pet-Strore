using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Model.BlogDetail;

namespace PetStore.Service
{
    public class BlogDetailService : IBlogDetailService
    {
        private readonly PetStoreDbContext _dbContext;

        public BlogDetailService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(BlogDetailModel model)
        {
            var item = new BlogDetail()
            {
                Id = Guid.NewGuid(),
                CommentID = (Guid)model.Id,
                Content = model.ContentDetail,
            };
            await _dbContext.BlogsDetails.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.BlogsDetails.FindAsync(id);
            _dbContext.BlogsDetails.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds( IEnumerable<Guid> id)
        {
            foreach (var item in id)
            {
                var finditem = await _dbContext.BlogsDetails.FindAsync(item);
                _dbContext.BlogsDetails.Remove(finditem);
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

        public async Task<int> Update(BlogDetailModel model)
        {
            var item = await _dbContext.BlogsDetails.FindAsync(model.Id);
            item.Content = model.ContentDetail;
            item.CommentID = Guid.NewGuid();
            _dbContext.BlogsDetails.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}