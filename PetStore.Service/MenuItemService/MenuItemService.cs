using Microsoft.EntityFrameworkCore;
using Pet_Store.Common.Common;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.MenuItem;

namespace PetStore.Service
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
                TypeMenu = model.TypeMenu,
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

        public async Task<ApiResult<Pagingnation<MenuItem>>> GetAllPaging(MenuItemSeachContext ctx)
        {
            var query = from a in _dbContext.MenuItems
                        orderby a.GhortOrder
                        select new { a };
            if (!string.IsNullOrEmpty(ctx.Keyword))
            {
                query = query.Where(x => x.a.MenuName.Contains(ctx.Keyword));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((ctx.PageIndex - 1) * ctx.PageSize)
                .Take(ctx.PageSize)
                .Select(u => new MenuItem()
                {
                    MenuName = u.a.MenuName,
                    GhortOrder = u.a.GhortOrder,
                    Icon = u.a.Icon,
                    Id = u.a.Id,
                    PanID = u.a.PanID,
                    TypeMenu = u.a.TypeMenu,
                })
                .ToListAsync();
            var pagination = new Pagingnation<MenuItem>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = ctx.PageIndex,
                PageSize = ctx.PageSize,
            };
            return new ApiSuccessResult<Pagingnation<MenuItem>>(pagination);
        }

        public async Task<MenuItemModel> GetById(Guid id)
        {
            var entity = await _dbContext.MenuItems.FirstOrDefaultAsync(c => c.Id == id);

            var entityModel = new MenuItemModel()
            {
                Id = entity.Id,
                GhortOrder = entity.GhortOrder,
                Icon = entity.Icon,
                MenuName = entity.MenuName,
                PanID = entity.PanID,
                TypeMenu = entity.TypeMenu
            };
            return entityModel;
        }

        public async Task<IList<MenuItemModel>> GetMenuCategory()
        {
            var query = from c in _dbContext.MenuItems
                        where c.TypeMenu == 20
                        select new { c };
            var entity = await query.Select(x => new MenuItemModel()
            {
                Id = x.c.Id,
                GhortOrder = x.c.GhortOrder,
                TypeMenu = x.c.TypeMenu,
                Icon = x.c.Icon,
                MenuName = x.c.MenuName,
                PanID = x.c.PanID
            }).ToListAsync();

            return entity;
        }

        public async Task<IList<MenuItemModel>> GetMenuSystem()
        {
            var query = from c in _dbContext.MenuItems
                        where c.TypeMenu == 10
                        select new { c };
            var entity = await query.Select(x => new MenuItemModel()
            {
                Id = x.c.Id,
                GhortOrder = x.c.GhortOrder,
                TypeMenu = x.c.TypeMenu,
                Icon = x.c.Icon,
                MenuName = x.c.MenuName,
                PanID = x.c.PanID
            }).ToListAsync();

            return entity;
        }

        public async Task<int> Update(MenuItem model)
        {
            var item = await _dbContext.MenuItems.FindAsync(model.Id);
            item.MenuName = model.MenuName;
            item.PanID = model.PanID;
            item.GhortOrder = model.GhortOrder;
            item.PanID = model.PanID;
            item.Icon = model.Icon;
            item.TypeMenu = model.TypeMenu;
            _dbContext.MenuItems.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}