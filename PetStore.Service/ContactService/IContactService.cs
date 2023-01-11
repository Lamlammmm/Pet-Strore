using Pet_Store.Data.Entities;

namespace PetStore.Service.ContactService
{
    public interface IContactService
    {
        Task<IList<Contact>> GetAll();

        Task<Contact> GetById(Guid id);

        Task<int> Create(Contact model);

        Task<int> Update(Contact model);

        Task<int> DeleteByIds(Guid id);

        Task<int> Delete(IEnumerable<Guid> id);
    }
}