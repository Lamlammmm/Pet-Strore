using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public class TagService : ITagService
    {
        private readonly PetStoreDbContext _dbContext;

        public TagService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Tag model)
        {
            var item = new Tag()
            {
                Id = Guid.NewGuid(),
                BlogId = model.BlogId,
                NameTag = model.NameTag,
            };
            await _dbContext.Tags.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.Tags.FindAsync(id);
            _dbContext.Tags.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> ids)
        {
            foreach (var item in ids)
            {
                var finditem = await _dbContext.Tags.FindAsync(item);
                _dbContext.Tags.Remove(finditem);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<Tag>> GetAll()
        {
            var list = await _dbContext.Tags.ToListAsync();
            return list;
        }

        public async Task<Tag> GetById(Guid id)
        {
            var item = await _dbContext.Tags.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(Tag model)
        {
            var item = await _dbContext.Tags.FindAsync(model.Id);
            item.BlogId = model.BlogId;
            item.NameTag = model.NameTag;
            _dbContext.Tags.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}