using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;

namespace PetStore.Service.MenuItemService
{
    public class MenuItemService : IMenuItemService
    {
        private readonly PetStoreDbContext _dbContext;

        public MenuItemService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(MenuItem model)
        {
            var item = new MenuItem()
            {
                GhortOrder = model.GhortOrder,
                Icon = model.Icon,
                Id = model.Id,
                MenuName = model.MenuName,
                PanID = model.PanID,
            };
            await _dbContext.MenuItems.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.MenuItems.FindAsync(id);
            _dbContext.MenuItems.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> ids)
        {
            foreach (var item in ids)
            {
                var finditem = await _dbContext.MenuItems.FindAsync(item);
                _dbContext.MenuItems.Remove(finditem);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<MenuItem>> GetAll()
        {
            var list = await _dbContext.MenuItems.ToListAsync();
            return list;
        }

        public async Task<MenuItem> GetById(Guid id)
        {
            var item = await _dbContext.MenuItems.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(MenuItem model)
        {
            var item = await _dbContext.MenuItems.FindAsync(model.Id);
            item.MenuName = model.MenuName;
            item.PanID = model.PanID;
            item.GhortOrder = model.GhortOrder;
            item.PanID = model.PanID;
            item.Icon = model.Icon;
            _dbContext.MenuItems.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}