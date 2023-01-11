using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public interface IContactService
    {
        Task<IList<Contact>> GetAll();

        Task<Contact> GetById(Guid id);

        Task<int> Create(Contact model);

        Task<int> Update(Contact model);

        Task<int> Delete(Guid id);

        Task<int> DeleteByIds(IEnumerable<Guid> id);
    }
}