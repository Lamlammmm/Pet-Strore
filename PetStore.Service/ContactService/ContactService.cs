using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public class ContactService : IContactService
    {
        private readonly PetStoreDbContext _dbContext;

        public ContactService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Contact model)
        {
            var item = new Contact()
            {
                Id = model.Id,
                Content = model.Content,
                Icon = model.Icon,
                Title = model.Title
            };
            await _dbContext.Contacts.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> id)
        {
            foreach (var item in id)
            {
                var finditem = await _dbContext.Contacts.FindAsync(item);
                _dbContext.Contacts.Remove(finditem);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.Contacts.FindAsync(id);
            _dbContext.Contacts.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<Contact>> GetAll()
        {
            var list = await _dbContext.Contacts.ToListAsync();
            return list;
        }

        public async Task<Contact> GetById(Guid id)
        {
            var item = await _dbContext.Contacts.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(Contact model)
        {
            var item = await _dbContext.Contacts.FindAsync(model);
            item.Id = model.Id;
            item.Content = model.Content;
            item.Title = model.Title;
            item.Icon = model.Icon;
            _dbContext.Contacts.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}