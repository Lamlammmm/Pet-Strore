using Pet_Store.Data.Entities;

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
    }
}