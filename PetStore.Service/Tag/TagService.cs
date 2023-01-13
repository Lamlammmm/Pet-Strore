using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Service
{
    public class TagService:ITagService
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
                BlogId=model.BlogId,
                NameTag=model.NameTag,
            };
            await _dbContext.Tags.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIds(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Tag>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Tag modil)
        {
            throw new NotImplementedException();
        }
    }
}
