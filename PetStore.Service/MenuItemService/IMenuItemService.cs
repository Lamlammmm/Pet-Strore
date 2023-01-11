using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.MenuItem;

namespace PetStore.Service
{
    public interface IMenuItemService
    {
        Task<IList<MenuItem>> GetAll();

        Task<MenuItem> GetById(Guid id);

        Task<int> Create(MenuItem model);

        Task<int> Update(MenuItem model);

        Task<int> DeleteByIds(IEnumerable<Guid> ids);
        Task<int> Delete(Guid id);
        Task<ApiResult<Pagingnation<MenuItem>>> GetAllPaging(MenuItemSeachContext ctx);
    }
}